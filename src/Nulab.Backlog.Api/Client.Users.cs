namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using Data.Responses;

    public partial class Client : IUsers
    {
        async Task<BacklogResponse<User>> IUsers.GetAsync(int id)
        {
            var response = await GetAsync($"/api/v2/users/{id}");
            return await CreateResponseAsync<User>(response, HttpStatusCode.OK);
        }
    }
}
