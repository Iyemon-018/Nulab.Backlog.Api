namespace Nulab.Backlog.Api
{
    using System.Linq;
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

        public HttpRequestMessage AsRequestMessage(string baseUri
                                                 , ApiTokenCredentials apiTokenCredentials)
        {
            _parameter.Add(apiTokenCredentials.AsParameter());
            var requestUri = RequestUri(baseUri, _parameter);

            return new HttpRequestMessage(_httpMethod, requestUri);
        }

        public HttpContent AsContent()
        {
            var values = _parameter.ToKeyValuePairs().ToArray();
            return new FormUrlEncodedContent(values);
        }
    }
}