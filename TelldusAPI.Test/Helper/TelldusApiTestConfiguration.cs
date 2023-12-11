using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TelldusAPI.Test
{
    [TestClass]
    public abstract class TelldusApiTestConfiguration
    {
        public static string consumerKey;
        public static string consumerSecret;
        public static string accessToken;
        public static string accessTokenSecret;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            consumerKey = "your consumer key";
            consumerSecret = "your secret key";
            accessToken = "your access token";
            accessTokenSecret = "your secret token";
        }
    }
}
