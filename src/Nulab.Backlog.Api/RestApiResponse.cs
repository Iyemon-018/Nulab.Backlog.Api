namespace Nulab.Backlog.Api
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Extensions;
    using Newtonsoft.Json;

    internal sealed class RestApiResponse
    {
        private readonly HttpResponseMessage _response;

        private readonly JsonSerializer _serializer;

        public RestApiResponse(HttpResponseMessage response
                             , JsonSerializer serializer)
        {
            _response   = response;
            _serializer = serializer;
            StatusCode  = _response.StatusCode;

            Limit     = response.TryGetValue("X-RateLimit-Limit");
            Remaining = response.TryGetValue("X-RateLimit-Remaining");
            Reset     = response.TryGetDateTimeValue("X-RateLimit-Reset");
        }

        public HttpStatusCode StatusCode { get; }
        
        public int Limit { get; }

        public int Remaining { get; }

        public DateTime Reset { get; }

        public async Task<T> DeserializeContentAsync<T>()
        {
            await using var stream       = await _response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var       streamReader = new StreamReader(stream);
            using var       jsonReader   = new JsonTextReader(streamReader);

            return _serializer.Deserialize<T>(jsonReader);
        }
    }
}