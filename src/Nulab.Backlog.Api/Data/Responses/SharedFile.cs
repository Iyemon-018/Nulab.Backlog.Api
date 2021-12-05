namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class SharedFile
    {
        public int id { get; set; }
        
        public string type { get; set; }
        
        public string dir { get; set; }
        
        public string name { get; set; }
        
        public int size { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
        
        public User updatedUser { get; set; }
        
        public DateTime? updated { get; set; }
    }
}