namespace Nulab.Backlog.Api.Data.Responses
{
    public class Content
    {
        public int id { get; set; }

        public int key_id { get; set; }
        
        public string summary { get; set; }
        
        public string description { get; set; }
        
        public Comment comment { get; set; }
        
        public Change[] changes { get; set; }
        
        public object[] attachments { get; set; }
        
        public object[] shared_files { get; set; }
    }
}