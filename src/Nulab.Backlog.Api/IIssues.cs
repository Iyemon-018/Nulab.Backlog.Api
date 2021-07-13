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
    }
}