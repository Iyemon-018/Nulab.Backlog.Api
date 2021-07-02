namespace Nulab.Backlog.Api.Extensions
{
    using System;
    using System.Linq;
    using System.Net.Http;

    internal static class HttpResponseMessageHeaderExtensions
    {
        public static int TryGetValue(this HttpResponseMessage self, string name, int defaultValue = 0)
        {
            return self.Headers.TryGetValues(name, out var values) ? int.Parse(values.FirstOrDefault()) : defaultValue;
        }

        public static DateTime TryGetDateTimeValue(this HttpResponseMessage self
                                                 , string name)
        {
            // ヘッダー情報がないケースは、API 仕様が変わったことを意味するため、例外が発生することを想定していない。
            var values = self.Headers.GetValues(name);

            return long.Parse(values.FirstOrDefault()).FromUnixTime();
        }
    }
}