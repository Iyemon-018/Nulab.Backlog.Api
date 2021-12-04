namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class Assignee
    {
        public int id { get; set; }

        public string userId { get; set; }
        
        public string name { get; set; }
        
        public int roleType { get; set; }
        
        public string lang { get; set; }
        
        public string mailAddress { get; set; }
        
        public NulabAccount nulabAccount { get; set; }
        
        public string keyword { get; set; }
    }
}