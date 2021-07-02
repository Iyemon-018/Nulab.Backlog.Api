namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Data.Responses;
    using Newtonsoft.Json;

    public sealed partial class Client : IBacklogClient
    {
        private readonly ApiTokenClient _client;

        public Client(string baseUri
                    , JsonSerializer serializer = null)
        {
            _client = new ApiTokenClient(baseUri, serializer);
        }
        
        public void AddCredentials(ApiTokenCredentials credentials) => _client.AddCredentials(credentials);

        private async Task<BacklogResponse<T>> CreateResponseAsync<T>(RestApiResponse response
                                                                    , HttpStatusCode successStatusCode)
        {
            if (response.StatusCode == successStatusCode)
            {
                var content      = await response.DeserializeContentAsync<T>();
                var rateLimiting = new RateLimiting(response.Limit, response.Remaining, response.Reset);
                return new BacklogResponse<T>(response.StatusCode, content, rateLimiting);
            }
            else
            {
                var errors = await response.DeserializeContentAsync<Errors>();
                return new BacklogResponse<T>(response.StatusCode, errors);
            }
        }

        private async Task<RestApiResponse> GetAsync(string url
                                                   , QueryParameters parameter = null)
        {
            var request = new RestApiRequest(url, HttpMethod.Get, parameter);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        public IUsers Users => this;

        public ISpace Space => this;

        public IProjects Projects => this;
    }
}