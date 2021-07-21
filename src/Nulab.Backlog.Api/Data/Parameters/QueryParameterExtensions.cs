namespace Nulab.Backlog.Api.Data.Parameters
{
    internal static class QueryParameterExtensions
    {
        public static QueryParameters AsParameter<T>(this T self) where T : IQueryParameter => self.AsParameter();
    }
}