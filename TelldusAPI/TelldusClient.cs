using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelldusAPI
{
    public interface ITelldusClient
    {
        Task<IList<Device>> GetDevicesAsync();
        Task<IList<Sensor>> GetSensorsAsync();
        Task<Response> TurnOnAsync(int deviceId);
        Task<Response> TurnOffAsync(int deviceId);
        /// <summary>
        /// Sets the light level
        /// </summary>
        /// <param name="deviceId">Uniq id for the device to dim</param>
        /// <param name="lighLevel">A value between 0.0d and 1.0d</param>
        /// <returns><see cref="Response"/></returns>
        Task<Response> DimAsync(int deviceId, double dimAmount);
    }

    public class TelldusClient : ITelldusClient
    {
        private readonly HttpClient httpClient;
        private readonly string path = "http://api.telldus.com";
        private readonly IHttpClientInterpretationStrategy interpretationStrategy;

        public TelldusClient(HttpClient httpClient, IHttpClientInterpretationStrategy interpretationStrategy)
        {
            this.httpClient = httpClient;
            this.interpretationStrategy = interpretationStrategy;
        }

        public async Task<IList<Device>> GetDevicesAsync()
        {
            var requestUri = $"{path}/{interpretationStrategy.ResponseType}/devices/list";
            var response = await httpClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            return interpretationStrategy.DeserializeObject<Devices>(content).Device;
        }

        public async Task<IList<Sensor>> GetSensorsAsync()
        {
            var requestUri = $"{path}/{interpretationStrategy.ResponseType}/sensors/list?includeValues=1";
            var response = await httpClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();
            return interpretationStrategy.DeserializeObject<Sensors>(content).Sensor;
        }

        public async Task<Response> TurnOnAsync(int deviceId)
        {
            var requestUri = $"{path}/{interpretationStrategy.ResponseType}/device/turnOn?id={deviceId}";
            var content = await httpClient.GetStringAsync(requestUri);
            return interpretationStrategy.DeserializeObject<Response>(content);
        }

        public async Task<Response> TurnOffAsync(int deviceId)
        {
            var requestUri = $"{path}/{interpretationStrategy.ResponseType}/device/turnOff?id={deviceId}";
            string content = await httpClient.GetStringAsync(requestUri);
            return interpretationStrategy.DeserializeObject<Response>(content);
        }

        /// <summary>
        /// Sets the light level
        /// </summary>
        /// <param name="deviceId">Uniq id for the device to dim</param>
        /// <param name="lighLevel">A value between 0.0d and 1.0d</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<Response> DimAsync(int deviceId, double lighLevel)
        {
            var level = (int)(255.0d * lighLevel);
            var requestUri = $"{path}/{interpretationStrategy.ResponseType}/device/dim?id={deviceId}&level={level}";
            var content = await httpClient.GetStringAsync(requestUri);
            return interpretationStrategy.DeserializeObject<Response>(content);
        }
    }
}