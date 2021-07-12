namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class Webhook
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public string description { get; set; }
        
        public string hookUrl { get; set; }
        
        public bool allEvent { get; set; }
        
        public int[] activityTypeIds { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
        
        public User updatedUser { get; set; }
        
        public DateTime updated { get; set; }
    }
}