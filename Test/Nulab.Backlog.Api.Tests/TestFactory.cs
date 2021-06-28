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

        public static Client CreateClient()
        {
            using var textReader = File.OpenText(Path.Combine(Environment.CurrentDirectory, "api-test.json"));
            using var jsonReader = new JsonTextReader(textReader);

            var data   = DefaultSerializer.Deserialize<ApiTestData>(jsonReader);
            var client = new Client(data.baseUri);

            client.AddCredentials(new ApiTokenCredentials(data.apiKey));

            return client;
        }
    }
}