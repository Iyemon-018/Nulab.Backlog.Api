namespace Nulab.Backlog.Api
{
    using Nulab.Backlog.Api.Data.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBacklogClient
    {
        IUsers Users { get; }

        ISpace Space { get; }

        IProjects Projects { get; }

        /// <summary>
        /// 優先度一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-priority-list/#
        /// </remarks>
        Task<BacklogResponse<List<Priority>>> GetPrioritiesAsync();
    }
}