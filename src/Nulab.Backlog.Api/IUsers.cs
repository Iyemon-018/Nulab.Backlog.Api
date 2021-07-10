namespace Nulab.Backlog.Api
{
    using System;
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
        /// ユーザーの受け取ったスター一覧を取得します。
        /// </summary>
        /// <param name="userId">ユーザーのID</param>
        /// <param name="minId">最小ID</param>
        /// <param name="maxId">最大ID</param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-received-star-list/#
        /// </remarks>
        Task<BacklogResponse<List<Star>>> GetStarsAsync(int userId
                                                      , int? minId = null
                                                      , int? maxId = null
                                                      , int? count = null
                                                      , string order = null);

        /// <summary>
        /// ユーザーの受け取ったスターの数を取得します。
        /// </summary>
        /// <param name="userId">ユーザーのID</param>
        /// <param name="since">指定した日付以降のスターをカウント</param>
        /// <param name="until">指定した日付以前のスターをカウント</param>
        /// <returns></returns>
        Task<BacklogResponse<StarsCount>> GetStarsCountAsync(int userId, DateTime? since = null, DateTime? until = null);

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
        Task<BacklogResponse<List<RecentlyViewedIssue>>> GetRecentlyViewedIssuesAsync(string order = null, int? offset = null, int? count = null);

        /// <summary>
        /// 自分が最近見たプロジェクト一覧を取得します。
        /// </summary>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <param name="offset"></param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-projects/#
        /// </remarks>
        Task<BacklogResponse<List<RecentlyViewedProject>>> GetRecentlyViewedProjectsAsync(string order = null, int? offset = null, int? count = null);

        /// <summary>
        /// 自分が最近見たWiki一覧を取得します。
        /// </summary>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <param name="offset"></param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-wikis/#
        /// </remarks>
        Task<BacklogResponse<List<RecentlyViewedWiki>>> GetRecentlyViewedWikisAsync(string order = "", int? offset = null, int? count = null);
    }
}