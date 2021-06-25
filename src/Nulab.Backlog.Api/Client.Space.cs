namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Threading.Tasks;
    using Data.Responses;

    public partial class Client : ISpace
    {
        async Task<BacklogResponse<Space>> ISpace.GetAsync()
        {
            var response = await GetAsync($"/api/v2/space");
            return await CreateResponseAsync<Space>(response, HttpStatusCode.OK);
        }
    }
}
