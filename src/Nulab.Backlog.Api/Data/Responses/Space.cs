namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public class Space
    {
        public string spaceKey { get; set; }

        public string name { get; set; }

        public int ownerId { get; set; }

        public string lang { get; set; }

        public string timezone { get; set; }

        public string reportSendTime { get; set; }

        public string textFormattingRule { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }
    }
}