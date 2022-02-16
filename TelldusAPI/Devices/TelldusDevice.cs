using System.Linq;
using System.Threading.Tasks;

namespace TelldusAPI.Devices
{
    public abstract class TelldusDevice
    {
        private readonly string name;
        protected readonly ITelldusClient client;
        
        public int DeviceId { get; private set; }

        public TelldusDevice(string name, ITelldusClient client)
        {
            this.name = name;
            this.client = client;
        }

        protected async Task InitiateAsync()
        {
            if (DeviceId == 0)
            {
                var devices = await client.GetDevicesAsync();
                var device = devices.Single(x => x.Name == name);
                DeviceId = device.Id;
            }
        }
    }
}