namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Responses;

    public partial class Client : IConfigurations
    {
        async Task<BacklogResponse<List<Priority>>> IConfigurations.GetPrioritiesAsync()
        {
            var response = await GetAsync($"/api/v2/priorities").ConfigureAwait(false);

            return await CreateResponseAsync<List<Priority>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Resolution>>> IConfigurations.GetResolutionsAsync()
        {
            var response = await GetAsync($"/api/v2/resolutions").ConfigureAwait(false);

            return await CreateResponseAsync<List<Resolution>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
