namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public interface INotifications
    {
        /// <summary>
        /// お知らせ一覧を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-notification/#
        /// </remarks>
        Task<BacklogResponse<List<Notification>>> GetListAsync(GetNotificationsParameter parameter);

        /// <summary>
        /// お知らせ数を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-notification/#
        /// </remarks>
        Task<BacklogResponse<NotificationCount>> GetCountAsync();
    }
}