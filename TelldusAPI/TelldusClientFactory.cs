using SlackWebHookWrapper;
using System.Net.Http;

namespace TelldusAPI
{
    public static class TelldusClientFactory
    {
        public static ITelldusClient CreateJsonInterpretedTelldusClient(HttpClient httpClient)
        {
            return new TelldusClient(httpClient, new JsonInterpretationStrategy(new SlackLogger()));
        }

        public static ITelldusClient CreateXmlInterpretedTelldusClient(HttpClient httpClient)
        {
            return new TelldusClient(httpClient, new XmlInterpretationStrategy());
        }
    }

    public class SlackLogger : ITelldusApiLogger
    {
        public void Log(string message)
        {
            var logger = Hooks.CreateTelldusSlackHook;
            logger.Header = "Telldus";
            logger.Subtext = message;
            logger.Send();
        }
    }
}