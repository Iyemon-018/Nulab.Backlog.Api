namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class WikiPageHistory
    {
        public int pageId { get; set; }

        public int version { get; set; }
        
        public string name { get; set; }
        
        public string content { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
    }
}