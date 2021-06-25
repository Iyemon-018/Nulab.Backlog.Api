using System;
using Xunit;

namespace Nulab.Backlog.Api.Tests
{
    using System.Threading.Tasks;

    public class UnitTest1
    {
        [Fact]
        public async Task Test_ƒVƒiƒŠƒI()
        {
            var client = new Client("https://motex-mark.backlog.com");
            client.AddCredentials(new ApiTokenCredentials("NYiHVWYeWN7KZCQtYADwla7KseUKikrttCN8k45CREy3IslhLi9fJXbpBidzFzB8"));
            var response = await client.Projects.GetUsersAsync("DEVELOP_ONE").ConfigureAwait(false);
            response.IsSuccess.IsTrue();
        }
    }
}
