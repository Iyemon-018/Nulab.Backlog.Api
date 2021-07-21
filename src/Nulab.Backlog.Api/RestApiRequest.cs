namespace Nulab.Backlog.Api
{
    using System.Net.Http;
    using Data.Parameters;

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

        public string RequestUri(string baseUri
                               , ApiTokenCredentials apiTokenCredentials)
        {
            var parameter = new QueryParameters().Add(apiTokenCredentials.AsParameter());

            return RequestUri(baseUri, parameter);
        }

        public string RequestUri(string baseUri
                               , QueryParameters parameter)
        {
            return $"{baseUri}{_url}{parameter}";
        }

        public HttpRequestMessage BuildRequestMessage(string baseUri
                                      , ApiTokenCredentials apiTokenCredentials)
        {
            _parameter.Add(apiTokenCredentials.AsParameter());
            var requestUri = RequestUri(baseUri, _parameter);

            return new HttpRequestMessage(_httpMethod, requestUri);
        }

        public HttpContent BuildContent()
        {
            var values = _parameter.ToKeyValuePairs();
            return new FormUrlEncodedContent(values);
        }
    }
}