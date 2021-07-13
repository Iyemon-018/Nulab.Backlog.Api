namespace Nulab.Backlog.Api
{
    using System.ComponentModel.DataAnnotations;

    public enum OrderType
    {
        [Display(Name = "desc")]
        Desc,

        [Display(Name = "asc")]
        Asc,
    }
}