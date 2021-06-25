namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IProjects
    {
        /// <summary>
        /// プロジェクトユーザー一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-user-list/#
        /// </remarks>
        Task<BacklogResponse<List<ProjectUser>>> GetUsersAsync(string projectIdOrKey);
    }
}