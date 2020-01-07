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

        public async Task<bool> InitiateAuthorizationAsync()
        {
            requestTokenInfo = await tinyOAuth.GetRequestTokenAsync();
            var url = tinyOAuth.GetAuthorizationUrl(requestTokenInfo.RequestToken);
            return true;
        }

        public async Task<AccessTokenInfo> FinalizeAuthorizationAsync()
        {
            return await tinyOAuth.GetAccessTokenAsync(requestTokenInfo.RequestToken, requestTokenInfo.RequestTokenSecret, string.Empty);
        }
    }
}