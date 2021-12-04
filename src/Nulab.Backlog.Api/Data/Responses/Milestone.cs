namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class Milestone
    {
        public int id { get; set; }

        public int projectId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public object startDate { get; set; }

        public object releaseDueDate { get; set; }

        public bool archived { get; set; }

        public int displayOrder { get; set; }
    }
}