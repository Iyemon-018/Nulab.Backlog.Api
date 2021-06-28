namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Responses;

    public partial class Client : IProjects
    {
        async Task<BacklogResponse<List<ProjectUser>>> IProjects.GetUsersAsync(string projectIdOrKey
                                                                             , bool? excludeGroupMembers = null)
        {
            var parameter = new QueryParameters().Add(nameof(excludeGroupMembers), excludeGroupMembers);
            var response  = await GetAsync($"/api/v2/projects/{projectIdOrKey}/users", parameter);

            return await CreateResponseAsync<List<ProjectUser>>(response, HttpStatusCode.OK);
        }
    }
}
