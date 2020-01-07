using TinyOAuth1;

namespace TelldusAPI
{
    public class TelldusOAuthConfig : TinyOAuthConfig
    {
        public TelldusOAuthConfig(string consumerKey, string consumerSecret)
        {
            AccessTokenUrl = "https://api.telldus.com/oauth/accessToken";
            AuthorizeTokenUrl = "https://api.telldus.com/oauth/authorize";
            RequestTokenUrl = "https://api.telldus.com/oauth/requestToken";
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        public TinyOAuth GetOAuth() => new TinyOAuth(this);
    }
}