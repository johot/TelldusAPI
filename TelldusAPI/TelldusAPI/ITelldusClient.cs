using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelldusAPI
{
    public interface ITelldusClient
    {
        void Authorize();

        /// <summary>
        /// Login using previously stored login information.
        /// </summary>
        Task Login();

        bool IsLoggedIn { get; set; }

        Task<Response> TurnOff(Device device);

        /// <summary>
        /// Dim amount should be a value between 0.0d and 1.0d.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="dimAmount"></param>
        /// <returns></returns>
        Task<Response> Dim(Device device, double dimAmount);

        Task<Response> TurnOn(Device device);
        Task<IList<Device>> GetDevices();
        void LoginAsNewUser();
    }
}