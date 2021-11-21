namespace Nulab.Backlog.Api.Data.Parameters
{
    public sealed class CommentParameter : IQueryParameter
    {
        private int? minId;

        private int? maxId;

        private int? count;

        private OrderType? order;

        public CommentParameter(int? minId = default
                              , int? maxId = default
                              , int? count = default
                              , OrderType? order = default)
        {
            this.minId = minId;
            this.maxId = maxId;
            this.count = count;
            this.order = order;
        }

        QueryParameters IQueryParameter.AsParameter()
            => new QueryParameters().Add(nameof(minId), minId)
                                    .Add(nameof(maxId), maxId)
                                    .Add(nameof(count), count)
                                    .Add(nameof(order), EnumValueCache<OrderType>.GetString(order));
    }
}