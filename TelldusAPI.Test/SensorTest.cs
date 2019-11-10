using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TelldusAPI.Test
{
    [TestClass]
    public class SensorTest
    {
        /// <summary>
        /// Integration test
        /// </summary>
        /// <returns>Nothing. Will crash if authorization is wrong.</returns>
        [TestMethod]
        async public Task GetAllSensorsTest()
        {
            var cosumerKey = System.Environment.GetEnvironmentVariable("TelldusConsumerKey");
            var cosumerSecret = System.Environment.GetEnvironmentVariable("TelldusConsumerSecret");
            var accessToken = System.Environment.GetEnvironmentVariable("TelldusAccessToken");
            var accessTokenSecret = System.Environment.GetEnvironmentVariable("TelldusAccessTokenSecret");

            var client = new TelldusClient(cosumerKey, cosumerSecret);
            client.Authorize(accessToken, accessTokenSecret);

            var sensors = await client.GetSensorsAsync();
        }
    }
}
