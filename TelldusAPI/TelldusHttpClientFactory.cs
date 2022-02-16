using System.Net.Http;
using TinyOAuth1;

namespace TelldusAPI
{
    public class TelldusHttpClientFactory
    {
        private readonly TinyOAuthConfig config;
        private readonly ITelldusApiLogger logger;

        public TelldusHttpClientFactory(TelldusOAuthConfig config, ITelldusApiLogger logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public IHttpClient CreateClient(string accessToken, string accessTokenSecret)
        {
            var client = new HttpClient(new TinyOAuthMessageHandler(config, accessToken, accessTokenSecret));
            return new HttpClientWithLogging(client, new JsonInterpretationStrategy(logger), logger);
        }
    }
}