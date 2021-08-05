namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : INotifications
    {
        async Task<BacklogResponse<List<Notification>>> INotifications.GetListAsync(GetNotificationsParameter parameter)
        {
            var response = await GetAsync($"/api/v2/notifications", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Notification>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
