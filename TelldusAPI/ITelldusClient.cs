using System.Collections.Generic;
using System.Threading.Tasks;
using TinyOAuth1;

namespace TelldusAPI
{
    public interface ITelldusClient
    {
        //Task<Response> TurnOff(Device device);

        ///// <summary>
        ///// Dim amount should be a value between 0.0d and 1.0d.
        ///// </summary>
        ///// <param name="device"></param>
        ///// <param name="dimAmount"></param>
        ///// <returns></returns>
        //Task<Response> Dim(Device device, double dimAmount);

        //Task<Response> TurnOnAsync(Device device);
		
	    Task<string> GetAuthorizationUrlAsync();
	    Task<IList<Device>> GetDevicesAsync();
	    Task<AccessTokenInfo> FinalizeAuthorizationAsync();
	    void Authorize(string accessToken, string accessTokenSecret);
    }
}