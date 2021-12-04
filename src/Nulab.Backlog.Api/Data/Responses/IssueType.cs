namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class IssueType
    {
        public int id { get; set; }

        public int projectId { get; set; }
        
        public string name { get; set; }
        
        public string color { get; set; }
        
        public int displayOrder { get; set; }

        public string templateSummary { get; set; }

        public string templateDescription { get; set; }
    }
}