namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class Watching
    {
        public int id { get; set; }

        public bool resourceAlreadyRead { get; set; }

        public string note { get; set; }

        public string type { get; set; }

        public Issue issue { get; set; }

        public DateTime? lastContentUpdated { get; set; }

        public DateTime created { get; set; }

        public DateTime? updated { get; set; }
    }
}