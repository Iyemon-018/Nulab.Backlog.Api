namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IUsers
    {
        /// <summary>
        /// ユーザー一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user-list/#
        /// </remarks>
        Task<BacklogResponse<List<User>>> GetListAsync();

        /// <summary>
        /// ユーザー情報を取得します。
        /// </summary>
        /// <param name="id">ユーザーのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user/#
        /// </remarks>
        Task<BacklogResponse<User>> GetAsync(int id);

        /// <summary>
        /// 認証ユーザー情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-own-user/#
        /// </remarks>
        Task<BacklogResponse<LoginUser>> GetMySelfAsync();

        /// <summary>
        /// ユーザーの最近の活動を取得します。
        /// </summary>
        /// <param name="userId">ユーザーのID</param>
        /// <param name="activityTypeId">type(1-17)</param>
        /// <param name="minId">最小ID</param>
        /// <param name="maxId">最大ID</param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user-recent-updates/#
        /// </remarks>
        Task<BacklogResponse<List<UserActivity>>> GetActivitiesAsync(int userId
                                                                    , int[] activityTypeId = null
                                                                    , int? minId = null
                                                                    , int? maxId = null
                                                                    , int? count = null
                                                                    , string order = null);

        /// <summary>
        /// 自分が最近見た課題一覧を取得します。
        /// </summary>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <param name="offset"></param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-issues/#
        /// </remarks>
        Task<BacklogResponse<List<RecentlyViewedIssue>>> GetRecentlyViewedIssuesAsync(string order = "", int offset = 0, int count = 20);
    }
}