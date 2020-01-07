using System.Net.Http;
using TinyOAuth1;

namespace TelldusAPI
{
    public class TelldusHttpClientFactory
    {
        private readonly TinyOAuthConfig config;

        public TelldusHttpClientFactory(TelldusOAuthConfig config)
        {
            this.config = config;
        }

        public HttpClient AuthorizeAndGetHttpClient(string accessToken, string accessTokenSecret)
        {
            return new HttpClient(new TinyOAuthMessageHandler(config, accessToken, accessTokenSecret));
        }
    }
}