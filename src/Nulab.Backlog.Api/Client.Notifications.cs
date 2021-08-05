namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : INotifications
    {
        /// <summary>
        /// お知らせ一覧を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-notification/#
        /// </remarks>
        async Task<BacklogResponse<List<Notification>>> INotifications.GetListAsync(GetNotificationsParameter parameter)
        {
            var response = await GetAsync($"/api/v2/notifications", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Notification>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// お知らせ数を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-notification/#
        /// </remarks>
        async Task<BacklogResponse<NotificationCount>> INotifications.GetCountAsync()
        {
            var response = await GetAsync($"/api/v2/notifications/count").ConfigureAwait(false);

            return await CreateResponseAsync<NotificationCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
