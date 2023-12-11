using System;
using System.Threading.Tasks;

namespace TelldusAPI.Devices
{
    public class DimmableDevice: TelldusDevice
    {
        public DimmableDevice(string deviceName, ITelldusClient client) : base(deviceName, client) { }

        public async Task DimAsync(double level)
        {
            if (level < 0 || level > 255)
            {
                throw new ArgumentOutOfRangeException($"{nameof(level)} must be a value between 0 and 255");
            }

            await InitiateAsync();
            await client.DimAsync(DeviceId, level);
        }

        public async Task TurnOffAsync()
        {
            await InitiateAsync();
            await client.TurnOffAsync(DeviceId);
        }

        public async Task TurnOnAsync()
        {
            await InitiateAsync();
            await client.TurnOnAsync(DeviceId);
        }
    }
}