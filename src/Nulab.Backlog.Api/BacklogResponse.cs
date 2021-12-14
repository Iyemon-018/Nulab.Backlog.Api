namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Data.Responses;

    public sealed class BacklogResponse<T>
    {
        public BacklogResponse(HttpStatusCode     statusCode
                             , HttpRequestMessage requestMessage
                             , T                  content
                             , RateLimiting       rateLimiting)
        {
            StatusCode   = statusCode;
            RequestUri   = requestMessage.RequestUri;
            Content      = content;
            RateLimiting = rateLimiting;
        }

        public BacklogResponse(HttpStatusCode     statusCode
                             , HttpRequestMessage requestMessage
                             , Errors             errors)
        {
            StatusCode = statusCode;
            Errors     = errors;
        }

        public bool IsSuccess => Errors == null || !Errors.HasError;

        public HttpStatusCode StatusCode { get; }

        public T Content { get; }

        public RateLimiting RateLimiting { get; }

        public Errors Errors { get; }

        public Uri RequestUri { get; }

        public IEnumerable<string> AsErrorMessages() => IsSuccess ? Enumerable.Empty<string>() : Errors.AsMessages();
    }
}