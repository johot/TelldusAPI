using System.Net.Http;

namespace TelldusAPI
{
    public static class TelldusClientFactory
    {
        public static ITelldusClient CreateJsonInterpretedTelldusClient(HttpClient httpClient)
        {
            return new TelldusClient(httpClient, new JsonInterpretationStrategy());
        }

        public static ITelldusClient CreateXmlInterpretedTelldusClient(HttpClient httpClient)
        {
            return new TelldusClient(httpClient, new XmlInterpretationStrategy());
        }
    }
}
