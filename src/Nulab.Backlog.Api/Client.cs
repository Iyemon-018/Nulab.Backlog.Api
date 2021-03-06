namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Data.Responses;
    using Newtonsoft.Json;
    using Data.Parameters;

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
                return new BacklogResponse<T>(response.StatusCode, response.RequestMessage, content, rateLimiting);
            }
            else
            {
                var errors = await response.DeserializeContentAsync<Errors>();
                return new BacklogResponse<T>(response.StatusCode, response.RequestMessage, errors);
            }
        }

        private async Task<BacklogResponse<ContentFile>> CreateFileResponseAsync(RestApiResponse response
            , HttpStatusCode successStatusCode)
        {
            if (response.StatusCode == successStatusCode)
            {
                var content = response.AsFile();
                var rateLimiting = new RateLimiting(response.Limit, response.Remaining, response.Reset);
                return new BacklogResponse<ContentFile>(response.StatusCode, response.RequestMessage, content, rateLimiting);
            }
            else
            {
                var errors = await response.DeserializeContentAsync<Errors>();
                return new BacklogResponse<ContentFile>(response.StatusCode, response.RequestMessage, errors);
            }
        }

        private async Task<RestApiResponse> GetAsync(string url, IQueryParameter queryParameter) =>
            await GetAsync(url, queryParameter?.AsParameter()).ConfigureAwait(false);

        private async Task<RestApiResponse> GetAsync(string url
                                                   , QueryParameters parameter = null)
        {
            var request = new RestApiRequest(url, HttpMethod.Get, parameter);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        private async Task<RestApiResponse> PostAsync(string url
                                                    , IQueryParameter queryParameter)
        {
            var request = new RestApiRequest(url, HttpMethod.Post, queryParameter.AsParameter());

            return await _client.PostAsync(request).ConfigureAwait(false);
        }

        private async Task<RestApiResponse> PatchAsync(string url
                                                     , IQueryParameter parameter = null)
        {
            var request = new RestApiRequest(url, HttpMethod.Post, parameter.AsParameter());
            return await _client.PatchAsync(request).ConfigureAwait(false);
        }

        private async Task<RestApiResponse> DeleteAsync(string url)
        {
            var request = new RestApiRequest(url, HttpMethod.Delete, null);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        private async Task<RestApiResponse> PutAsync(string url, QueryParameters parameter = null)
        {
            var request = new RestApiRequest(url, HttpMethod.Put, parameter);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        public IUsers Users => this;

        public ISpace Space => this;

        public IProjects Projects => this;

        public IConfigurations Configurations => this;

        public IIssues Issues => this;

        public IWikis Wikis => this;

        public INotifications Notifications => this;

        public ITeams Teams => this;
    }
}