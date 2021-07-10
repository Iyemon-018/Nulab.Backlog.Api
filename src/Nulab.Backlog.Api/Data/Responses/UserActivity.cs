namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public class UserActivity
    {
        public int id { get; set; }

        public Project project { get; set; }

        public int type { get; set; }

        public Content content { get; set; }

        public Notification[] notifications { get; set; }

        public User createdUser { get; set; }

        public DateTime created { get; set; }
    }
}
