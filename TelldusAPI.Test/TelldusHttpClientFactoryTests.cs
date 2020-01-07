using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TelldusAPI.Test
{
    [TestClass]
    public class TelldusHttpClientFactoryTests : TelldusApiTestConfiguration
    {
        [TestMethod]
        public void CanAuthorizeAndGetHttpClientTest()
        {
            var telldusOAuthConfig = new TelldusOAuthConfig(consumerKey, consumerSecret);
            var telldusHttpClientFactory = new TelldusHttpClientFactory(telldusOAuthConfig);
            var httpClient = telldusHttpClientFactory.AuthorizeAndGetHttpClient(accessToken, accessTokenSecret);
            Assert.IsNotNull(httpClient, "Should be initialized if authorized");
        }
    }
}
