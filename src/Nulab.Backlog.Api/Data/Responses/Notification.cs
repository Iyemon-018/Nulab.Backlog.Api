namespace Nulab.Backlog.Api.Data.Responses
{
    public class Notification
    {
        public int id { get; set; }

        public bool alreadyRead { get; set; }

        public int reason { get; set; }

        public User user { get; set; }

        public bool resourceAlreadyRead { get; set; }
    }
}
