using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinyOAuth1;

namespace TelldusAPI
{
	public class TelldusClient : ITelldusClient
	{
		private readonly TinyOAuthConfig _config;
		private readonly TinyOAuth _tinyOAuth;
		private HttpClient _httpClient;
		private RequestTokenInfo _requestTokenInfo;

		public TelldusClient(string consumerKey, string consumerSecret)
		{
			_config = new TinyOAuthConfig
			{
				AccessTokenUrl = "https://api.telldus.com/oauth/accessToken",
				AuthorizeTokenUrl = "https://api.telldus.com/oauth/authorize",
				RequestTokenUrl = "https://api.telldus.com/oauth/requestToken",
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret
			};

			_tinyOAuth = new TinyOAuth(_config);
		}

		public async Task<string> GetAuthorizationUrlAsync()
		{
			_requestTokenInfo = await _tinyOAuth.GetRequestToken();
			var authorizationUrl = _tinyOAuth.GetAuthorizationUrl(_requestTokenInfo.RequestToken);

			return authorizationUrl;
		}

		public void Authorize(string accessToken, string accessTokenSecret)
		{
			_httpClient = new HttpClient(new TinyOAuthMessageHandler(_config, accessToken, accessTokenSecret));
		}

		public async Task<AccessTokenInfo> FinalizeAuthorizationAsync()
		{
			var accessTokenInfo = await _tinyOAuth.GetAccessToken(_requestTokenInfo.RequestToken, _requestTokenInfo.RequestTokenSecret, "");

			return accessTokenInfo;
		}

		public async Task<IList<Device>> GetDevicesAsync()
		{
			CheckIsAuthorized();

			var requestUri = "http://api.telldus.com/json/devices/list";

			var resp = await _httpClient.GetAsync(requestUri);
			var respJson = await resp.Content.ReadAsStringAsync();

			var devicesRoot = JsonConvert.DeserializeObject<Devices>(respJson);

			foreach (var device in devicesRoot.Device)
				device.TelldusClient = this;

			return devicesRoot.Device;
		}

		internal async Task<Response> TurnOffAsync(Device device)
		{
			var requestUri = "http://api.telldus.com/json/device/turnOff?id=" + device.Id;

			var data = await _httpClient.GetStringAsync(requestUri);

			var response = JsonConvert.DeserializeObject<Response>(data);

			return response;
		}

		/// <summary>
		///     Dim amount should be a value between 0.0d and 1.0d.
		/// </summary>
		/// <param name="device"></param>
		/// <param name="dimAmount"></param>
		/// <returns></returns>
		internal async Task<Response> DimAsync(Device device, double dimAmount)
		{
			var level = (int) (255.0d * dimAmount);

			var requestUri = "http://api.telldus.com/json/device/dim?id=" + device.Id + "&level=" + level;

			var data = await _httpClient.GetStringAsync(requestUri);

			var response = JsonConvert.DeserializeObject<Response>(data);

			return response;
		}

		internal async Task<Response> TurnOnAsync(Device device)
		{
			var requestUri = "http://api.telldus.com/json/device/turnOn?id=" + device.Id;

			var data = await _httpClient.GetStringAsync(requestUri);

			var response = JsonConvert.DeserializeObject<Response>(data);

			return response;
		}

		private void CheckIsAuthorized()
		{
			if (_httpClient == null)
				throw new Exception(
					"You need to perform authorization by calling the Authorize method (with your obtained access tokens) first. If you do not have your access tokens you need to call GetAuthorizationUrlAsync() followed by FinalizeAuthorizationAsync().");
		}
	}
}