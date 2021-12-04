namespace Nulab.Backlog.Api.Data.Responses
{
    public sealed class ProjectUser
    {
        public int id { get; set; }

        public string userId { get; set; }

        public string name { get; set; }

        public int roleType { get; set; }

        public string lang { get; set; }

        public string mailAddress { get; set; }

        public NulabAccount nulabAccount { get; set; }                                                

        public string keyword { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(userId)}: {userId}, {nameof(name)}: {name}, {nameof(roleType)}: {roleType}, {nameof(lang)}: {lang}, {nameof(mailAddress)}: {mailAddress}, {nameof(nulabAccount)}: {nulabAccount}, {nameof(keyword)}: {keyword}";
        }
    }
}
