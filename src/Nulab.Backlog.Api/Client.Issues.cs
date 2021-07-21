namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : IIssues
    {
        async Task<BacklogResponse<List<Issue>>> IIssues.GetListAsync(IssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Issue>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<IssueCount>> IIssues.GetCountAsync(IssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/count", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<IssueCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.GetAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.PostAsync(IssueParameter parameter)
        {
            var response = await PostAsync($"/api/v2/issues", parameter.AsParameter()).ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.Created).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Comment>>> IIssues.GetCommentsAsync(string issueIdOrKey, CommentParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Comment>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}