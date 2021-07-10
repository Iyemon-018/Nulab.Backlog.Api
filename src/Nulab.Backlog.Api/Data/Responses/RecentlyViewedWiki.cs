namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public class RecentlyViewedWiki
    {
        public WikiPage page { get; set; }

        public DateTime updated { get; set; }
    }
}