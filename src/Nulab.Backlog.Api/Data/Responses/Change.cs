namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class Change
    {
        public string field { get; set; }
        public string field_text { get; set; }
        public string new_value { get; set; }
        public string old_value { get; set; }
        public string type { get; set; }
    }
}