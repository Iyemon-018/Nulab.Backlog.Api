namespace Nulab.Backlog.Api.Data.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-watching-list/#%E3%82%AF%E3%82%A8%E3%83%AA%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public sealed class GetWatchingsParameter : IQueryParameter
    {
        private readonly int _userId;

        private readonly OrderType order;

        private readonly SortType sort;

        private readonly int? count;

        private readonly int? offset;

        private readonly bool? resourceAlreadyRead;

        private readonly int[] issueId;

        public GetWatchingsParameter(int userId
                                   , OrderType order = OrderType.Desc
                                   , SortType sort = SortType.IssueUpdated
                                   , int? count = default
                                   , int? offset = default
                                   , bool? resourceAlreadyRead = default
                                   , int[] issueId = default)
        {
            _userId                  = userId;
            this.order               = order;
            this.sort                = sort;
            this.count               = count;
            this.offset              = offset;
            this.resourceAlreadyRead = resourceAlreadyRead;
            this.issueId             = issueId;
        }

        public int UserId => _userId;

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(order), EnumValueCache<OrderType>.GetString(order))
                                  .Add(nameof(sort), EnumValueCache<SortType>.GetString(sort))
                                  .Add(nameof(count), count)
                                  .Add(nameof(offset), offset)
                                  .Add(nameof(resourceAlreadyRead), resourceAlreadyRead)
                                  .Add(nameof(issueId), issueId);
        }
    }
}