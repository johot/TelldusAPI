using System.Threading.Tasks;

namespace TelldusAPI.Sensors
{
    public class TemperatureSensor : TelldusSensor
    {
        public TemperatureSensor(string sensorName, ITelldusClient client) : base(sensorName, client) { }

        public async Task<decimal> GetTemperatureAsync()
        {
            var sensor = await GetSensorAsync();
            return sensor.Temp;
        }
    }
}