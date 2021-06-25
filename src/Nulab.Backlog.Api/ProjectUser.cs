using System;

namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    public class ProjectUser
    {
        public int id { get; set; }

        public string userId { get; set; }

        public string name { get; set; }

        public int roleType { get; set; }

        public string lang { get; set; }

        public string mailAddress { get; set; }
        public NulabAccount nulabAccount { get; set; }                                                

        public string keyword { get; set; }
    }

    public class NulabAccount
    {
        public string nulabId { get; set; }

        public string name { get; set; }

        public string uniqueId { get; set; }
    }

    public class Users
    {
        public User[] Values { get; set; }
    }

    public sealed class Client : ApiTokenClientBase
    {
        public Client(string baseUri
                    , JsonSerializer serializer = null) : base(baseUri, serializer)
        {
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
            return await SendAsync(request).ConfigureAwait(false);
        }
    }

    public class Space
    {
        public string spaceKey { get; set; }

        public string name { get; set; }

        public int ownerId { get; set; }

        public string lang { get; set; }

        public string timezone { get; set; }

        public string reportSendTime { get; set; }

        public string textFormattingRule { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }
    }

    public class BacklogResponse<T>
    {
        public BacklogResponse(HttpStatusCode statusCode
                             , T content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public BacklogResponse(HttpStatusCode statusCode
                             , Errors errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public bool IsSuccess => Errors == null || !Errors.HasError;

        public HttpStatusCode StatusCode { get; }

        public T Content { get; }

        public Errors Errors { get; }
    }

    public class Errors
    {
        private Error[] errors { get; set; }

        public Errors()
        {

        }

        public bool HasError => errors.Any();
    }

    /// <summary>
    /// https://developer.nulab.com/ja/docs/backlog/error-response/#
    /// </summary>
    public class Error
    {
        public Error(string message
                   , ErrorCode code
                   , string moreInfo)
        {
            this.message = message;
            this.code = code;
            this.moreInfo = moreInfo;
        }

        public Error()
        {

        }

        public string message { get; }

        public ErrorCode code { get; }

        public string moreInfo { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ErrorCode
    {
    }

    public sealed class User
    {
        public int id { get; set; }

        public string userId { get; set; }

        public string name { get; set; }

        public int roleType { get; set; }

        public string lang { get; set; }

        public string mailAddress { get; set; }
    }

    /// <summary>
    /// 参考: https://github.com/hal1932/NBacklog/blob/9a0b447e5019c941d9bd0b4a4bb667ca0334733d/NBacklog/Rest/RestClient.cs
    /// </summary>
    public abstract class ApiTokenClientBase
    {
        private readonly string _baseUri;

        private readonly JsonSerializer _serializer;

        private readonly HttpClient _httpClient;

        private static readonly JsonSerializer DefaultSerializer = new JsonSerializer
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include
        };

        private ApiTokenCredentials _credentials;

        protected ApiTokenClientBase(string baseUri, JsonSerializer serializer = null)
        {
            _baseUri = baseUri;
            _serializer = serializer ?? DefaultSerializer;
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AddCredentials(ApiTokenCredentials credentials) => _credentials = credentials;

        protected async Task<RestApiResponse> SendAsync(RestApiRequest request)
        {
            var httpRequest = request.Build(_baseUri, _credentials);
            var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            return new RestApiResponse(response, _serializer);
        }
    }

    public class RestApiResponse
    {
        private readonly HttpResponseMessage _response;
        private readonly JsonSerializer _serializer;

        public RestApiResponse(HttpResponseMessage response
                             , JsonSerializer serializer)
        {
            _response = response;
            _serializer = serializer;
            StatusCode = _response.StatusCode;
        }

        public HttpStatusCode StatusCode { get; }

        public async Task<T> DeserializeContentAsync<T>()
        {
            await using var stream = await _response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            return _serializer.Deserialize<T>(jsonReader);
        }
    }

    public class RestApiRequest
    {
        private readonly string _url;

        private readonly HttpMethod _httpMethod;

        private readonly object _parameter;

        public RestApiRequest(string url
                            , HttpMethod httpMethod
                            , object parameter)
        {
            _url = url;
            _httpMethod = httpMethod;
            _parameter = parameter;
        }

        public HttpRequestMessage Build(string baseUri
                                      , ApiTokenCredentials apiTokenCredentials)
        {
            return new HttpRequestMessage(_httpMethod, $"{baseUri}{_url}?{apiTokenCredentials.AsParameter()}");
        }
    }

    public sealed class ApiTokenCredentials
    {
        private readonly string _apiKey;

        public ApiTokenCredentials(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string AsParameter() => $"apiKey={_apiKey}";
    }
}
