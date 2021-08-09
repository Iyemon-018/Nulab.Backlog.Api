namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-teams/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E3%83%9C%E3%83%87%E3%82%A3
    /// </remarks>
    public sealed class Team
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public User[] members { get; set; }
        
        public object displayOrder { get; set; }
        
        public User createdUser { get; set; }
        
        public DateTime created { get; set; }
        
        public User updatedUser { get; set; }
        
        public DateTime? updated { get; set; }
    }
}