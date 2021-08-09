namespace Nulab.Backlog.Api.Data.Responses
{
    using System;
    using Extensions;

    public sealed class Limit
    {
        public int limit { get; set; }

        public int remaining { get; set; }

        public long reset { get; set; }
        
        public DateTime ResetToDateTime() => reset.FromUnixTime();
    }
}