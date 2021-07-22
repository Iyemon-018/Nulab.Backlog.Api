namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class CommentNotification
    {
        public int id { get; set; }

        public bool alreadyRead { get; set; }
        
        public NotificationReasonType reason { get; set; }

        public User user { get; set; }

        public bool resourceAlreadyRead { get; set; }
    }
}