namespace Nulab.Backlog.Api.Extensions
{
    using System;

    /// <summary>
    /// <see cref="DateTime"/> 型に関連する拡張メソッドを定義します。
    /// </summary>
    public static class DateTimeExtensions
    {
        private static TimeSpan LocalSystemUtcOffset = TimeZoneInfo.Local.BaseUtcOffset;

        internal static void SetUtcOffset(TimeSpan offset) => LocalSystemUtcOffset = offset;

        /// <summary>
        /// 日時を UNIX 時刻へ変換します。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <returns>UNIX 時間に変換された結果を返します。</returns>
        public static long ToUnixTime(this DateTime self) =>
            new DateTimeOffset(self.Ticks, LocalSystemUtcOffset).ToUnixTimeSeconds();

        /// <summary>
        /// UNIX 時刻を日時へ変換します。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <returns>変換結果の日時を返します。</returns>
        public static DateTime FromUnixTime(this long self)
            => DateTimeOffset.FromUnixTimeSeconds(self).Add(LocalSystemUtcOffset).DateTime;

        /// <summary>
        /// 日時をクエリパラメータ用の値に変換します。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <returns>変換結果の日付文字列を返します。</returns>
        internal static string AsDateValue(this DateTime? self) => self.HasValue ? self.Value.ToString("yyyy-MM-dd") : null;
    }
}