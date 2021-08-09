namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : ITeams
    {
        /// <summary>
        /// チーム一覧を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-teams/#
        /// </remarks>
        async Task<BacklogResponse<List<Team>>> ITeams.GetListAsync(GetTeamsParameter parameter)
        {
            var response = await GetAsync($"/api/v2/teams", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Team>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// チーム情報を取得します。
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-team/#
        /// </remarks>
        async Task<BacklogResponse<Team>> ITeams.GetAsync(int teamId)
        {
            var response = await GetAsync($"/api/v2/teams/{teamId}").ConfigureAwait(false);

            return await CreateResponseAsync<Team>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
