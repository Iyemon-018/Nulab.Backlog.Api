namespace Nulab.Backlog.Api.Data.Parameters
{
    internal interface IQueryParameter
    {
        QueryParameters AsParameter();
    }

    internal static class QueryParameterExtensions
    {
        internal static QueryParameters AsParameter<T>(this T self) where T : IQueryParameter => self.AsParameter();
    }
}