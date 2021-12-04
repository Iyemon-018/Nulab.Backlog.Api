namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class ProjectStatus
    {
        public int id { get; set; }

        public int projectId { get; set; }

        public string name { get; set; }

        public string color { get; set; }

        public int displayOrder { get; set; }
    }
}