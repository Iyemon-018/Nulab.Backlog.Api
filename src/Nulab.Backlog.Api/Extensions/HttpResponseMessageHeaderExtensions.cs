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
            // レスポンスが 4XX や 5XX の場合、ヘッダーにデータがない場合がある。
            // とりあえず異常と判断できるように .MinValue を返すものとしている。
            return self.Headers.TryGetValues(name, out var values) ? long.Parse(values.FirstOrDefault()).FromUnixTime() : DateTime.MinValue;
        }
    }
}