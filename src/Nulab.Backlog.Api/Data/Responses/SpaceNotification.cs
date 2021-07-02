namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space-notification/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E3%83%9C%E3%83%87%E3%82%A3
    /// </remarks>
    public sealed class SpaceNotification
    {
        public string content { get; set; }

        public DateTime? updated { get; set; }
    }
}