namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Responses;

    public partial class Client : IProjects
    {
        async Task<BacklogResponse<List<ProjectUser>>> IProjects.GetUsersAsync(string projectIdOrKey)
        {
            var response = await GetAsync($"/api/v2/projects/{projectIdOrKey}/users");
            return await CreateResponseAsync<List<ProjectUser>>(response, HttpStatusCode.OK);
        }
    }
}
