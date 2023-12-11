using System.Linq;
using System.Threading.Tasks;

namespace TelldusAPI.Sensors
{
    public abstract class TelldusSensor
    {
        private readonly string name;
        protected readonly ITelldusClient client;

        public TelldusSensor(string name, ITelldusClient client)
        {
            this.name = name;
            this.client = client;
        }

        protected async Task<Sensor> GetSensorAsync()
        {
            var sensors = await client.GetSensorsAsync();
            return sensors.Single(x => x.Name == name);
        }
    }
}