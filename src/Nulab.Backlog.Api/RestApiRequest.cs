namespace Nulab.Backlog.Api
{
    using System.Net.Http;

    internal sealed class RestApiRequest
    {
        private readonly string _url;

        private readonly HttpMethod _httpMethod;

        private readonly QueryParameters _parameter;

        public RestApiRequest(string url
                            , HttpMethod httpMethod
                            , QueryParameters parameter)
        {
            _url        = url;
            _httpMethod = httpMethod;
            _parameter  = parameter ?? new QueryParameters();
        }

        public HttpRequestMessage Build(string baseUri
                                      , ApiTokenCredentials apiTokenCredentials)
        {
            _parameter.Add(apiTokenCredentials.AsParameter());
            var requestUri = $"{baseUri}{_url}{_parameter}";

            return new HttpRequestMessage(_httpMethod, requestUri);
        }
    }
}