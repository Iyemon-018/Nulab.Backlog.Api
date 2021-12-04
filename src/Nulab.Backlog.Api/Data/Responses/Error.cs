namespace Nulab.Backlog.Api.Data.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/error-response/#
    /// </remarks>
    public sealed class Error
    {
        public Error()
        {

        }

        public string message { get; set; }

        public ErrorCode code { get; set; }

        public string moreInfo { get; set; }
    }
}