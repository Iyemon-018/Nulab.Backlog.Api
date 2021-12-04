namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class DiskUsageDetail
    {
        public int projectId { get; set; }

        public int issue { get; set; }

        public int wiki { get; set; }
        
        public int file { get; set; }
        
        public int subversion { get; set; }
        
        public int git { get; set; }
        
        public int gitLFS { get; set; }
        
        public int pullRequest { get; set; }
    }
}