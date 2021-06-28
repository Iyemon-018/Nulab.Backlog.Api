namespace Nulab.Backlog.Api.Tests
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    internal static class TestFactory
    {
        private static readonly JsonSerializer DefaultSerializer = new JsonSerializer
                                                                   {
                                                                       MissingMemberHandling = MissingMemberHandling.Ignore
                                                                     , NullValueHandling     = NullValueHandling.Include
                                                                     , DefaultValueHandling  = DefaultValueHandling.Include
                                                                   };

        private static Api.Client _client = null;

        private static ApiTestData _apiTestData = null;

        public static ApiTestData Load()
        {
            if (_apiTestData != null) return _apiTestData;

            using var textReader = File.OpenText(Path.Combine(Environment.CurrentDirectory, "api-test.json"));
            using var jsonReader = new JsonTextReader(textReader);

            _apiTestData = DefaultSerializer.Deserialize<ApiTestData>(jsonReader);
            return _apiTestData;
        }

        public static Api.Client CreateClient()
        {
            if (_client != null) return _client;

            var data   = Load();
            _client = new Api.Client(data.baseUri);

            _client.AddCredentials(new ApiTokenCredentials(data.apiKey));

            return _client;
        }
    }
}