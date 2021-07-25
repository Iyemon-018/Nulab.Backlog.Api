namespace Nulab.Backlog.Api.Data.Parameters
{
    public sealed class GetWikiListParameter : IQueryParameter
    {
        private readonly string projectIdOrKey;

        private readonly string keyword;

        public GetWikiListParameter(string projectIdOrKey = null
                                  , string keyword = default)
        {
            this.projectIdOrKey = projectIdOrKey;
            this.keyword        = keyword;
        }

        QueryParameters IQueryParameter.AsParameter()
            => QueryParameters.Build(nameof(projectIdOrKey), projectIdOrKey)
                              .Add(nameof(keyword), keyword);
    }
}