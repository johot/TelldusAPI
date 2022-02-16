using SlackWebHookWrapper;

namespace TelldusAPI
{
    public static class TelldusClientFactory
    {
        public static ITelldusClient CreateJsonInterpretedTelldusClient(IHttpClient httpClient)
        {
            return new TelldusClient(httpClient, new JsonInterpretationStrategy(new TelldusApiLogger(Hooks.CreateTelldusSlackHook)));
        }

        public static ITelldusClient CreateXmlInterpretedTelldusClient(IHttpClient httpClient)
        {
            return new TelldusClient(httpClient, new XmlInterpretationStrategy());
        }
    }
}