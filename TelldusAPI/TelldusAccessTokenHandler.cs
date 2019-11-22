using System.Threading.Tasks;
using TinyOAuth1;

namespace TelldusAPI
{
    public class TelldusAccessTokenHandler
    {
        private readonly TinyOAuth tinyOAuth;
        private RequestTokenInfo requestTokenInfo;

        public TelldusAccessTokenHandler(TinyOAuth tinyOAuth)
        {
            this.tinyOAuth = tinyOAuth;
        }

        public async Task<string> GetAuthorizationUrlAsync()
        {
            requestTokenInfo = await tinyOAuth.GetRequestTokenAsync();
            return tinyOAuth.GetAuthorizationUrl(requestTokenInfo.RequestToken);
        }

        public async Task<AccessTokenInfo> FinalizeAuthorizationAsync()
        {
            return await tinyOAuth.GetAccessTokenAsync(requestTokenInfo.RequestToken, requestTokenInfo.RequestTokenSecret, string.Empty);
        }
    }
}