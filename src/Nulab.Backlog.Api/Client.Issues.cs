namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : IIssues
    {
        async Task<BacklogResponse<List<Issue>>> IIssues.GetListAsync(GetIssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Issue>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<IssueCount>> IIssues.GetCountAsync(GetIssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/count", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<IssueCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.GetAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.AddAsync(IssueParameter parameter)
        {
            var response = await PostAsync($"/api/v2/issues", parameter.AsParameter()).ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.Created).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題情報を更新します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">追加する課題の情報</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-issue/#
        /// </remarks>
        async Task<BacklogResponse<Issue>> IIssues.UpdateAsync(string issueIdOrKey
                                                             , UpdateIssueParameter parameter)
        {
            var response = await PatchAsync($"/api/v2/issues/{issueIdOrKey}", parameter.AsParameter()).ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題を削除します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue/#
        /// </remarks>
        async Task<BacklogResponse<Issue>> IIssues.DeleteAsync(string issueIdOrKey)
        {
            var response = await DeleteAsync($"/api/v2/issues/{issueIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Comment>>> IIssues.GetCommentsAsync(string issueIdOrKey, CommentParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Comment>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}