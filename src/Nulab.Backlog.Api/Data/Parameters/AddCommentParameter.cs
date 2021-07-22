namespace Nulab.Backlog.Api.Data.Parameters
{
    public sealed class AddCommentParameter : IQueryParameter
    {
        private readonly string content;

        private readonly int[] notifiedUserId;

        private readonly int[] attachmentId;

        public AddCommentParameter(string content, int[] notifiedUserId = default, int[] attachmentId = default)
        {
            this.content        = content;
            this.notifiedUserId = notifiedUserId;
            this.attachmentId   = attachmentId;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(content), content)
                                  .Add(nameof(notifiedUserId), notifiedUserId)
                                  .Add(nameof(attachmentId), attachmentId);
        }
    }
}