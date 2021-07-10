namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public class WikiPage
    {
        public int id { get; set; }
    
        public int projectId { get; set; }
        
        public string name { get; set; }
        
        public Tag[] tags { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
        
        public User updatedUser { get; set; }
        
        public DateTime updated { get; set; }
    }
}