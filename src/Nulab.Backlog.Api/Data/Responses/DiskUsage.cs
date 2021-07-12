namespace Nulab.Backlog.Api.Data.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space-disk-usage/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E3%83%9C%E3%83%87%E3%82%A3
    /// </remarks>
    public sealed class DiskUsage
    {
        public int capacity { get; set; }

        public int issue { get; set; }
        
        public int wiki { get; set; }
        
        public int file { get; set; }
        
        public int subversion { get; set; }
        
        public int git { get; set; }
        
        public int gitLFS { get; set; }
        
        public int pullRequest { get; set; }
        
        public DiskUsageDetail[] details { get; set; }
    }
}