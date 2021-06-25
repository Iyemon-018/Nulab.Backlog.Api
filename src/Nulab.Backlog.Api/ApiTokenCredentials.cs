namespace Nulab.Backlog.Api
{
    public sealed class ApiTokenCredentials
    {
        private readonly string _apiKey;

        public ApiTokenCredentials(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string AsParameter() => $"apiKey={_apiKey}";
    }
}