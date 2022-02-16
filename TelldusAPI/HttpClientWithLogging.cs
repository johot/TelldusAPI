using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelldusAPI
{
    public interface IHttpClient
    {
        Task<T> GetAndReadAsync<T>(string requestUri);
    }

    public class HttpClientWithLogging : IHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly IHttpClientInterpretationStrategy interpretationStrategy;
        private readonly ITelldusApiLogger logger;

        public HttpClientWithLogging(HttpClient httpClient, IHttpClientInterpretationStrategy interpretationStrategy, ITelldusApiLogger logger)
        {
            this.httpClient = httpClient;
            this.interpretationStrategy = interpretationStrategy;
            this.logger = logger;
        }

        public async Task<T> GetAndReadAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri);
            LogAndThrowOnFail(requestUri, response);
            var content = await response.Content.ReadAsStringAsync();
            return interpretationStrategy.DeserializeObject<T>(content);
        }

        private void LogAndThrowOnFail(string requestUri, HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                logger.Log($"{requestUri}: responded: {responseMessage.StatusCode}, ReasonPhrase: {responseMessage.ReasonPhrase}");
            }

            responseMessage.EnsureSuccessStatusCode();
        }
    }
}