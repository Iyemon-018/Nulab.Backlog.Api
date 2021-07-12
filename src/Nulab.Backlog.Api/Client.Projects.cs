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

        async Task<BacklogResponse<Project>> IProjects.GetAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Project>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<ProjectUser>>> IProjects.GetUsersAsync(string projectIdOrKey
                                                                             , bool? excludeGroupMembers = null)
        {
            var parameter = new QueryParameters().Add(nameof(excludeGroupMembers), excludeGroupMembers);
            var response  = await GetAsync($"/api/v2/projects/{projectIdOrKey}/users", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<ProjectUser>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<User>>> IProjects.GetAdministratorsAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/administrators").ConfigureAwait(false);

            return await CreateResponseAsync<List<User>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<IssueType>>> IProjects.GetIssueTypesAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/issueTypes").ConfigureAwait(false);

            return await CreateResponseAsync<List<IssueType>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Category>>> IProjects.GetCategoriesAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/categories").ConfigureAwait(false);

            return await CreateResponseAsync<List<Category>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<ProjectVersion>>> IProjects.GetVersionsAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/versions").ConfigureAwait(false);

            return await CreateResponseAsync<List<ProjectVersion>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<CustomField>>> IProjects.GetCustomFieldsAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/customFields").ConfigureAwait(false);

            return await CreateResponseAsync<List<CustomField>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<SharedFile>>> IProjects.GetFilesAsync(string projectIdOrKey, string path)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/files/metadata/{path}").ConfigureAwait(false);

            return await CreateResponseAsync<List<SharedFile>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<ContentFile>> IProjects.GetFileContentAsync(string projectIdOrKey, int id)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/files/{id}").ConfigureAwait(false);

            return await CreateFileResponseAsync(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<DiskUsage>> IProjects.GetDiskUsageAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/diskUsage").ConfigureAwait(false);

            return await CreateResponseAsync<DiskUsage>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Webhook>>> IProjects.GetWebHooksAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/webhooks").ConfigureAwait(false);

            return await CreateResponseAsync<List<Webhook>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
