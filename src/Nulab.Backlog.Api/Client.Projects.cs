namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Responses;

    public partial class Client : IProjects
    {
        async Task<BacklogResponse<List<ProjectStatus>>> IProjects.GetStatuesAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/statuses").ConfigureAwait(false);

            return await CreateResponseAsync<List<ProjectStatus>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// プロジェクト一覧を取得します。
        /// </summary>
        /// <param name="archived">省略された場合は全てのプロジェクト、falseの場合はアーカイブされていないプロジェクト、trueの場合はアーカイブされたプロジェクトを返します。</param>
        /// <param name="all">ユーザが管理者権限の場合のみ有効なパラメータです。trueの場合はすべてのプロジェクト、falseの場合は参加しているプロジェクトのみを返します。初期値はfalse。</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-list/#
        /// </remarks>
        async Task<BacklogResponse<List<Project>>> IProjects.GetListAsync(bool? archived = null
                                                                    , bool? all = null)
        {
            var parameter = new QueryParameters().Add(nameof(archived), archived).Add(nameof(all), all);
            var response  = await GetAsync($"/api/v2/projects", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Project>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<ProjectUser>>> IProjects.GetUsersAsync(string projectIdOrKey
                                                                             , bool? excludeGroupMembers = null)
        {
            var parameter = new QueryParameters().Add(nameof(excludeGroupMembers), excludeGroupMembers);
            var response  = await GetAsync($"/api/v2/projects/{projectIdOrKey}/users", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<ProjectUser>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
