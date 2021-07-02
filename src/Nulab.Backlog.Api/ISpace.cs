namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface ISpace
    {
        /// <summary>
        /// スペース情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space/#
        /// </remarks>
        Task<BacklogResponse<Space>> GetAsync();

        /// <summary>
        /// 最近の更新を取得します。
        /// </summary>
        /// <param name="activityTypeId">type(1-26)</param>
        /// <param name="minId">最小ID</param>
        /// <param name="maxId">最大ID</param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-recent-updates/#
        /// <paramref name="activityTypeId"/> については https://developer.nulab.com/ja/docs/backlog/api/2/get-recent-updates/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E8%AA%AC%E6%98%8E を参照する。
        /// </remarks>
        Task<BacklogResponse<List<SpaceActivity>>> GetActivitiesAsync(int[] activityTypeId = null
                                                                    , int? minId = null
                                                                    , int? maxId = null
                                                                    , int? count = null
                                                                    , string order = null);

        /// <summary>
        /// スペースのお知らせを取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space-notification/#
        /// </remarks>
        Task<BacklogResponse<SpaceNotification>> GetNotificationAsync();

        /// <summary>
        /// スペースのお知らせを更新します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-space-notification/#
        /// </remarks>
        Task<BacklogResponse<SpaceNotification>> PutNotificationAsync(string content);
    }
}