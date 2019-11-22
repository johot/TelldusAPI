using System.Net.Http;

namespace TelldusAPI.Test
{
    public class TelldusApiTestHelper
    {
        private readonly HttpClient httpClient;
        public TelldusApiTestHelper()
        {
            var telldusOAuthConfig = new TelldusOAuthConfig(TelldusApiTestConfiguration.consumerKey, TelldusApiTestConfiguration.consumerSecret);
            var telldusHttpClientFactory = new TelldusHttpClientFactory(telldusOAuthConfig);
            httpClient = telldusHttpClientFactory.AuthorizeAndGetHttpClient(TelldusApiTestConfiguration.accessToken, TelldusApiTestConfiguration.accessTokenSecret);
        }

        public ITelldusClient CreateTelldusClient(ClientType clientType = ClientType.JSON)
        {
            if (clientType == ClientType.XML)
            {
                return TelldusClientFactory.CreateXmlInterpretedTelldusClient(httpClient);
            }

            return TelldusClientFactory.CreateJsonInterpretedTelldusClient(httpClient);
        }
    }

    public enum ClientType
    {
        JSON = 1,
        XML = 2,
    }
}
