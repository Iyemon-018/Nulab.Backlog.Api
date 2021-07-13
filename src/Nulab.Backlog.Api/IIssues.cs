namespace Nulab.Backlog.Api
{
    using Data.Parameters;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IIssues
    {
        /// <summary>
        /// 課題一覧を取得します。
        /// </summary>
        /// <param name="parameter">クエリパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-list/#
        /// </remarks>
        Task<BacklogResponse<List<Issue>>> GetListAsync(IssuesParameter parameter);

        /// <summary>
        /// 課題数を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-issue/#
        /// </remarks>
        Task<BacklogResponse<IssueCount>> GetCountAsync(IssuesParameter parameter);

        /// <summary>
        /// 課題情報を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue/#
        /// </remarks>
        Task<BacklogResponse<Issue>> GetAsync(string issueIdOrKey);
    }
}