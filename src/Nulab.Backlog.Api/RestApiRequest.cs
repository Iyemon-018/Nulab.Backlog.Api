﻿namespace Nulab.Backlog.Api
{
    using System.Net.Http;

    internal sealed class RestApiRequest
    {
        private readonly string _url;

        private readonly HttpMethod _httpMethod;

        private readonly object _parameter;

        public RestApiRequest(string url
                            , HttpMethod httpMethod
                            , object parameter)
        {
            _url        = url;
            _httpMethod = httpMethod;
            _parameter  = parameter;
        }

        public HttpRequestMessage Build(string baseUri
                                      , ApiTokenCredentials apiTokenCredentials)
        {
            return new HttpRequestMessage(_httpMethod, $"{baseUri}{_url}?{apiTokenCredentials.AsParameter()}");
        }
    }
}