namespace Nulab.Backlog.Api.Data.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/update-comment/#%E3%83%AA%E3%82%AF%E3%82%A8%E3%82%B9%E3%83%88%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public sealed class UpdateIssueCommentParameter : IQueryParameter
    {
        private readonly string content;

        public UpdateIssueCommentParameter(string content)
        {
            this.content = content;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(content), content);
        }
    }
}