namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class Star
    {
        public int id { get; set; }

        public object comment { get; set; }
        
        public string url { get; set; }
        
        public string title { get; set; }
        
        public User presenter { get; set; }
        
        public DateTime created { get; set; }
    }
}
