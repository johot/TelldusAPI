namespace TelldusAPI
{
    public class XmlInterpretationStrategy : IHttpClientInterpretationStrategy
    {
        public string ResponseType => "xml";

        public T DeserializeObject<T>(string response) where T : class
        {
            return XmlConvert.DeserializeObject<T>(response);
        }
    }
}