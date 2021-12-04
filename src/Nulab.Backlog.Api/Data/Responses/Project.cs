namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class Project
    {
        public int id { get; set; }
        
        public string projectKey { get; set; }
        
        public string name { get; set; }
        
        public bool chartEnabled { get; set; }
        
        public bool subtaskingEnabled { get; set; }
        
        public bool projectLeaderCanEditProjectLeader { get; set; }
        
        public bool useWikiTreeView { get; set; }
        
        public string textFormattingRule { get; set; }
        
        public bool archived { get; set; }
        
        public int displayOrder { get; set; }
        
        public bool useDevAttributes { get; set; }
    }
}