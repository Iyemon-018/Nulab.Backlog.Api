namespace Nulab.Backlog.Api.Data.Parameters
{
    public sealed class AddCommentNotificationParameter : IQueryParameter
    {
        private readonly int[] notifiedUserId;

        public AddCommentNotificationParameter(int[] notifiedUserId)
        {
            this.notifiedUserId = notifiedUserId;
        }

        QueryParameters IQueryParameter.AsParameter() => QueryParameters.Build(nameof(notifiedUserId), notifiedUserId);
    }
}