using System.Collections.Generic;
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
        /// <param name="level">A value between 0 and 255</param>
        /// <returns><see cref="Response"/></returns>
        Task<Response> DimAsync(int deviceId, double level);
    }

    public class TelldusClient : ITelldusClient
    {
        private readonly IHttpClient httpClient;
        private readonly string path = "http://pa-api.telldus.com";
        private readonly IHttpClientInterpretationStrategy interpretationStrategy;

        public TelldusClient(IHttpClient httpClient, IHttpClientInterpretationStrategy interpretationStrategy)
        {
            this.httpClient = httpClient;
            this.interpretationStrategy = interpretationStrategy;
        }

        public async Task<IList<Device>> GetDevicesAsync()
        {
            var container = await httpClient.GetAndReadAsync<DeviceContainer>($"{path}/{interpretationStrategy.ResponseType}/devices/list?includeIgnored=1");
            return container.Device;
        }

        public async Task<IList<Sensor>> GetSensorsAsync()
        {
            var container = await httpClient.GetAndReadAsync<SensorContainer>($"{path}/{interpretationStrategy.ResponseType}/sensors/list?includeValues=1");
            return container.Sensor;
        }

        public Task<Response> TurnOnAsync(int deviceId)
        {
            return httpClient.GetAndReadAsync<Response>($"{path}/{interpretationStrategy.ResponseType}/device/turnOn?id={deviceId}");
        }

        public Task<Response> TurnOffAsync(int deviceId)
        {
            return httpClient.GetAndReadAsync<Response>($"{path}/{interpretationStrategy.ResponseType}/device/turnOff?id={deviceId}");
        }

        /// <summary>
        /// Sets the light level
        /// </summary>
        /// <param name="deviceId">Uniq id for the device to dim</param>
        /// <param name="level">A value between 0 and 255</param>
        /// <returns><see cref="Response"/></returns>
        public Task<Response> DimAsync(int deviceId, double level)
        {
            return httpClient.GetAndReadAsync<Response>($"{path}/{interpretationStrategy.ResponseType}/device/dim?id={deviceId}&level={level}");
        }
    }
}