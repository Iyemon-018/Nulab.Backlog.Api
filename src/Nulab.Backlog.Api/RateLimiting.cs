namespace Nulab.Backlog.Api
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/rate-limit/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E3%83%98%E3%83%83%E3%83%80
    /// </remarks>
    public sealed class RateLimiting
    {
        public int Limit { get; }

        public int Remaining { get; }

        public DateTime Reset { get; }

        public bool CanSendRequest => Remaining > 0;

        public RateLimiting(int limit
                          , int remaining
                          , DateTime reset)
        {
            Limit     = limit;
            Remaining = remaining;
            Reset     = reset;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"X-RateLimit-Limit: {Limit}, X-RateLimit-Remaining: {Remaining}, X-RateLimit-Reset: {Reset}";
        }
    }
}