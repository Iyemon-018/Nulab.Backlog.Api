namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public class Issue
    {
        public int id { get; set; }
        
        public int projectId { get; set; }
        
        public string issueKey { get; set; }
        
        public int keyId { get; set; }
        
        public IssueType issueType { get; set; }
        
        public string summary { get; set; }
        
        public string description { get; set; }
        
        public object resolution { get; set; }
        
        public Priority priority { get; set; }
        
        public Status status { get; set; }
        
        public Assignee assignee { get; set; }
        
        public Category[] category { get; set; }
        
        public object[] versions { get; set; }
        
        public object[] milestone { get; set; }
        
        public DateTime? startDate { get; set; }
        
        public DateTime? dueDate { get; set; }
        
        public object estimatedHours { get; set; }
        
        public object actualHours { get; set; }
        
        public int? parentIssueId { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
        
        public User updatedUser { get; set; }
        
        public DateTime updated { get; set; }
        
        public object[] customFields { get; set; }
        
        public object[] attachments { get; set; }
        
        public object[] sharedFiles { get; set; }
        
        public object[] stars { get; set; }
    }
}