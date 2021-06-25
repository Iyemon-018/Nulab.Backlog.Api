namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Data.Responses;
    using Newtonsoft.Json;

    public sealed class Client
    {
        private readonly ApiTokenClient _client;

        public Client(string baseUri
                    , JsonSerializer serializer = null)
        {
            _client = new ApiTokenClient(baseUri, serializer);
        }

        public async Task<BacklogResponse<User>> GetUserAsync(int id)
        {
            var response = await GetAsync($"/api/v2/users/{id}");
            return await CreateResponseAsync<User>(response, HttpStatusCode.OK);
        }

        public async Task<BacklogResponse<Space>> GetSpaceAsync()
        {
            var response = await GetAsync($"/api/v2/space");
            return await CreateResponseAsync<Space>(response, HttpStatusCode.OK);
        }

        public async Task<BacklogResponse<List<ProjectUser>>> GetProjectUsersAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/users");
            return await CreateResponseAsync<List<ProjectUser>>(response, HttpStatusCode.OK);
        }

        public void AddCredentials(ApiTokenCredentials credentials) => _client.AddCredentials(credentials);

        private async Task<BacklogResponse<T>> CreateResponseAsync<T>(RestApiResponse response
                                                                    , HttpStatusCode successStatusCode)
        {
            if (response.StatusCode == successStatusCode)
            {
                var content = await response.DeserializeContentAsync<T>();
                return new BacklogResponse<T>(response.StatusCode, content);
            }
            else
            {
                var errors = await response.DeserializeContentAsync<Errors>();
                return new BacklogResponse<T>(response.StatusCode, errors);
            }
        }

        private async Task<RestApiResponse> GetAsync(string url
                                                   , object parameter = null)
        {
            var request = new RestApiRequest(url, HttpMethod.Get, parameter);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }
    }
}