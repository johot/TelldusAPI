using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TelldusAPI.Test
{
    [TestClass]
    public class HelloWorldTests
    {
        [TestMethod]
        [Ignore("Need valid keys to work")]
        public async Task HelloWorldTest()
        {
            var telldusOAuthConfig = new TelldusOAuthConfig("your consumer key", "your consumer secret");
            var telldusHttpClientFactory = new TelldusHttpClientFactory(telldusOAuthConfig);
            var httpClient = telldusHttpClientFactory.AuthorizeAndGetHttpClient("your access token", "your secret access token");
            var client = TelldusClientFactory.CreateJsonInterpretedTelldusClient(httpClient);
            var data = await client.GetSensorsAsync();
        }
    }
}