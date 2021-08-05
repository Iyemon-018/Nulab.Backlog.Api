namespace Nulab.Backlog.Api.Data.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-history/#%E3%82%AF%E3%82%A8%E3%83%AA%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public sealed class GetWikiPageHistoriesParameter : IQueryParameter
    {
        private readonly int wikiId;

        private readonly int? minId;
        
        private readonly int? maxId;
        
        private readonly int? count;
        
        private readonly string order;

        public GetWikiPageHistoriesParameter(int wikiId
                                           , int? minId = default
                                           , int? maxId = default
                                           , int? count = default
                                           , string order = default)
        {
            this.wikiId = wikiId;
            this.minId  = minId;
            this.maxId  = maxId;
            this.count  = count;
            this.order  = order;
        }

        public int WikiId => wikiId;

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(minId), minId)
                                  .Add(nameof(maxId), maxId)
                                  .Add(nameof(count), count)
                                  .Add(nameof(order), order);
        }
    }
}