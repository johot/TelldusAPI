using Newtonsoft.Json;

namespace TelldusAPI
{
    public class JsonInterpretationStrategy : IHttpClientInterpretationStrategy
    {
        public string ResponseType => "json";

        public T DeserializeObject<T>(string response) where T : class
        {
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}