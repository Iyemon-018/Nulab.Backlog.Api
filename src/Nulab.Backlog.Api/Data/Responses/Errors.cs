namespace Nulab.Backlog.Api.Data.Responses
{
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/error-response/#
    /// </remarks>
    public class Errors
    {
        private Error[] errors { get; set; }

        public Errors()
        {

        }

        public bool HasError => errors.Any();
    }
}