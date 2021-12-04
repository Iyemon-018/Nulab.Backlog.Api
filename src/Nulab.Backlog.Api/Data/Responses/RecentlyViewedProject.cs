namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class RecentlyViewedProject
    {
        public Project project { get; set; }

        public DateTime updated { get; set; }
    }
}