namespace Nulab.Backlog.Api.Data.Parameters
{
    public sealed class GetWatchingCountParameter : IQueryParameter
    {
        private readonly int _userId;

        private readonly bool? resourceAlreadyRead;

        private readonly bool? alreadyRead;

        public GetWatchingCountParameter(int userId
                                       , bool? resourceAlreadyRead = default
                                       , bool? alreadyRead = default)
        {
            _userId                  = userId;
            this.resourceAlreadyRead = resourceAlreadyRead;
            this.alreadyRead         = alreadyRead;
        }

        public int UserId => _userId;

        QueryParameters IQueryParameter.AsParameter()
        {
            return QueryParameters.Build(nameof(resourceAlreadyRead), resourceAlreadyRead).Add(nameof(alreadyRead), alreadyRead);
        }
    }
}