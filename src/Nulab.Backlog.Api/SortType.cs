namespace Nulab.Backlog.Api
{
    using System.ComponentModel.DataAnnotations;

    public enum SortType
    {
        [Display(Name = "created")]
        Created,

        [Display(Name = "updated")]
        Updated,

        [Display(Name = "issueUpdated")]
        IssueUpdated,
    }
}