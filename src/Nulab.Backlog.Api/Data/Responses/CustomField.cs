namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class CustomField
    {
        public int id { get; set; }

        public int typeId { get; set; }
        
        public string name { get; set; }
        
        public string description { get; set; }
        
        public bool required { get; set; }
        
        public IssueType[] applicableIssueTypes { get; set; }
        
        public bool allowAddItem { get; set; }
        
        public FieldItem[] items { get; set; }
    }
}