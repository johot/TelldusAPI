namespace TelldusAPI
{
    public class XmlInterpretationStrategy : IHttpClientInterpretationStrategy
    {
        public string ResponseType => "xml";

        public T DeserializeObject<T>(string response)
        {
            return XmlConvert.DeserializeObject<T>(response);
        }
    }
}