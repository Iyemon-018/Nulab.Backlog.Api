namespace Nulab.Backlog.Api.Data.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-teams/#%E3%82%AF%E3%82%A8%E3%83%AA%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public class GetTeamsParameter : IQueryParameter
    {
        private readonly OrderType? order;

        private readonly int? offset;

        private readonly int? count;

        public GetTeamsParameter(OrderType? order = default
                               , int? offset = default
                               , int? count = default)
        {
            this.order  = order;
            this.offset = offset;
            this.count  = count;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(order), EnumValueCache<OrderType>.GetString(order))
                                  .Add(nameof(offset), offset)
                                  .Add(nameof(count), count);
        }
    }
}