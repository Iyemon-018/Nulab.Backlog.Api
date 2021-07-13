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
    }
}