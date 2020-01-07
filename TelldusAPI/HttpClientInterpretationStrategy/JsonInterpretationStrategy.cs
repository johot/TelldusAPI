using Newtonsoft.Json;
using System;
using TelldusAPI.Data;

namespace TelldusAPI
{
    public class JsonInterpretationStrategy : IHttpClientInterpretationStrategy
    {
        private readonly ITelldusApiLogger logger;
        public JsonInterpretationStrategy(ITelldusApiLogger logger)
        {
            this.logger = logger;
        }

        public string ResponseType => "json";

        public T DeserializeObject<T>(string response) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex)
            {
                try
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    logger.Log($"Could not deserialize {typeof(T)}, {error.Error} {error.Subcode} {error.Code} {error.Subcode}");
                    throw;
                }
                catch
                {
                    logger.Log($"Could not deserialize ErrorResponse, {ex}, {ex.InnerException}");
                    throw;
                }
            }
        }
    }
}