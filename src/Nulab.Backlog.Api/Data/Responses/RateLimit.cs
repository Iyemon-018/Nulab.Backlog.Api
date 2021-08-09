namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class RateLimit
    {
        public Limit read { get; set; }
 
        public Limit update { get; set; }
        
        public Limit search { get; set; }
        
        public Limit icon { get; set; }
    }
}