namespace Nulab.Backlog.Api.Tests
{
    using Newtonsoft.Json;

    internal static class JsonSerializeExtension
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
                                                                   {

                                                                       MissingMemberHandling = MissingMemberHandling.Ignore
                                                                     , NullValueHandling     = NullValueHandling.Include
                                                                     , DefaultValueHandling  = DefaultValueHandling.Include
                                                                     , Formatting            = Formatting.Indented
                                                                   };
        public static string ToJson(this object self
                                  , JsonSerializerSettings settings = null)
        {

            return JsonConvert.SerializeObject(self, settings ?? _settings);
        }
    }
}