using System.Collections.Generic;
using System.Threading.Tasks;
using TinyOAuth1;

namespace TelldusAPI
{
	public interface ITelldusClient
	{
		Task<string> GetAuthorizationUrlAsync();
		Task<IList<Device>> GetDevicesAsync();
        Task<IList<Sensor>> GetSensorsAsync();
		Task<AccessTokenInfo> FinalizeAuthorizationAsync();
		void Authorize(string accessToken, string accessTokenSecret);
		Task<Response> TurnOffAsync(string deviceId);

		/// <summary>
		///     Dim amount should be a value between 0.0d and 1.0d.
		/// </summary>
		/// <param name="device"></param>
		/// <param name="dimAmount"></param>
		/// <returns></returns>
		Task<Response> DimAsync(string deviceId, double dimAmount);

		Task<Response> TurnOnAsync(string deviceId);
	}
}