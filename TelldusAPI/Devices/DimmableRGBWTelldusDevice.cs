using System;
using System.Drawing;
using System.Threading.Tasks;

namespace TelldusAPI.Devices
{

    public class DimmableRGBWTelldusDevice: DimmableDevice
    {
        private readonly DimmableDevice red;
        private readonly DimmableDevice green;
        private readonly DimmableDevice blue;
        private readonly DimmableDevice white;

        public DimmableRGBWTelldusDevice(string deviceName, string redDeviceName, string greenDeviceName, string blueDeviceName, string whiteDeviceName, ITelldusClient client) : base(deviceName, client)
        {
            red = new DimmableDevice(redDeviceName, client);
            green = new DimmableDevice(greenDeviceName, client);
            blue = new DimmableDevice(blueDeviceName, client);
            white = new DimmableDevice(whiteDeviceName, client);
        }

        public async Task SetColorAsync(Color color)
        {
            await red.DimAsync(color.R);
            await green.DimAsync(color.G);
            await blue.DimAsync(color.B);
            await white.DimAsync(Math.Round(color.GetBrightness() * 255, 0));
        }

        public async Task DimAsync(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} must be a value between 0 and 100"); 
            }

            await DimAsync(Math.Round(value * 2.55, 0));
        }
    }
}