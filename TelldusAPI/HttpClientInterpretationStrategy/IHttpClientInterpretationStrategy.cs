namespace TelldusAPI
{
    public interface IHttpClientInterpretationStrategy
    {
        string ResponseType { get; }

        T DeserializeObject<T>(string response) where T : class;
    }
}