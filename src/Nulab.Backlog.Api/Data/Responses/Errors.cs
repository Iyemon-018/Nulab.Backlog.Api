namespace Nulab.Backlog.Api.Data.Responses
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/error-response/#
    /// </remarks>
    public class Errors
    {
        public Error[] errors { get; set; }

        public Errors()
        {

        }

        public bool HasError => errors != null || errors.Any();

        public IEnumerable<string> AsMessages() => HasError ? errors.Select(x => x.message) : Enumerable.Empty<string>();
    }
}