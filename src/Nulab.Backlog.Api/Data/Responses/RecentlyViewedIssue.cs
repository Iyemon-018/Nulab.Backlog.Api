namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class RecentlyViewedIssue
    {
        public Issue issue { get; set; }

        public DateTime updated { get; set; }
    }
}