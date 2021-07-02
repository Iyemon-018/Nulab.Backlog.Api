namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Responses;

    public partial class Client : ISpace
    {
        async Task<BacklogResponse<Space>> ISpace.GetAsync()
        {
            var response = await GetAsync($"/api/v2/space").ConfigureAwait(false);

            return await CreateResponseAsync<Space>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

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
        async Task<BacklogResponse<List<SpaceActivity>>> ISpace.GetActivitiesAsync(int[] activityTypeId = null
                                                                                 , int? minId = null
                                                                                 , int? maxId = null
                                                                                 , int? count = null
                                                                                 , string? order = null)
        {
            var parameter = new QueryParameters().Add(nameof(activityTypeId), activityTypeId)
                                                 .Add(nameof(minId), minId)
                                                 .Add(nameof(maxId), maxId)
                                                 .Add(nameof(count), count)
                                                 .Add(nameof(order), order);
            var response = await GetAsync($"/api/v2/space/activities", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<SpaceActivity>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// スペースのお知らせを取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space-notification/#
        /// </remarks>
        async Task<BacklogResponse<SpaceNotification>> ISpace.GetNotificationAsync()
        {
            var response = await GetAsync($"/api/v2/space/notification").ConfigureAwait(false);

            return await CreateResponseAsync<SpaceNotification>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// スペースのお知らせを更新します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-space-notification/#
        /// </remarks>
        async Task<BacklogResponse<SpaceNotification>> ISpace.PutNotificationAsync(string content)
        {
            var parameter = new QueryParameters().Add(nameof(content), content);
            var response  = await PutAsync($"/api/v2/space/notification", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<SpaceNotification>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// スペースの容量使用状況を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space-disk-usage/#
        /// </remarks>
        async Task<BacklogResponse<DiskUsage>> ISpace.GetDiskUsageAsync()
        {
            var response = await GetAsync($"/api/v2/space/diskUsage").ConfigureAwait(false);

            return await CreateResponseAsync<DiskUsage>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
