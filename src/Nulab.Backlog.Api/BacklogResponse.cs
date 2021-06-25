namespace Nulab.Backlog.Api
{
    using System.Net;
    using Data.Responses;

    public sealed class BacklogResponse<T>
    {
        public BacklogResponse(HttpStatusCode statusCode
                             , T content)
        {
            StatusCode = statusCode;
            Content    = content;
        }

        public BacklogResponse(HttpStatusCode statusCode
                             , Errors errors)
        {
            StatusCode = statusCode;
            Errors     = errors;
        }

        public bool IsSuccess => Errors == null || !Errors.HasError;

        public HttpStatusCode StatusCode { get; }

        public T Content { get; }

        public Errors Errors { get; }
    }
}