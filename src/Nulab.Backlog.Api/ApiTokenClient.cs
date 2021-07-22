namespace Nulab.Backlog.Api
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// 参考: https://github.com/hal1932/NBacklog/blob/9a0b447e5019c941d9bd0b4a4bb667ca0334733d/NBacklog/Rest/RestClient.cs
    /// </summary>
    internal sealed class ApiTokenClient
    {
        private readonly string _baseUri;

        private readonly JsonSerializer _serializer;

        private readonly HttpClient _httpClient;

        private ApiTokenCredentials _credentials;

        private static readonly JsonSerializer DefaultSerializer = new JsonSerializer
                                                                   {
                                                                       MissingMemberHandling = MissingMemberHandling.Ignore,
                                                                       NullValueHandling     = NullValueHandling.Include,
                                                                       DefaultValueHandling  = DefaultValueHandling.Include
                                                                   };

        public ApiTokenClient(string baseUri, JsonSerializer serializer = null)
        {
            _baseUri    = baseUri;
            _serializer = serializer ?? DefaultSerializer;
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AddCredentials(ApiTokenCredentials credentials) => _credentials = credentials;

        public async Task<RestApiResponse> SendAsync(RestApiRequest request)
        {
            var httpRequest = request.AsRequestMessage(_baseUri, _credentials);
            var response    = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            return new RestApiResponse(response, _serializer);
        }

        public async Task<RestApiResponse> PostAsync(RestApiRequest request)
        {
            var requestUri = request.RequestUri(_baseUri, _credentials);
            var content    = request.AsContent();
            var response   = await _httpClient.PostAsync(requestUri, content).ConfigureAwait(false);

            return new RestApiResponse(response, _serializer);
        }

        public async Task<RestApiResponse> PatchAsync(RestApiRequest request)
        {
            var requestUri = request.RequestUri(_baseUri, _credentials);
            var content    = request.AsContent();
            var response   = await _httpClient.PatchAsync(requestUri, content).ConfigureAwait(false);

            return new RestApiResponse(response, _serializer);
        }
    }
}