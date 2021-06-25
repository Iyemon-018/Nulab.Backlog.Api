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
            client.AddCredentials(new ApiTokenCredentials(""));
            var response = await client.GetProjectUsersAsync("DEVELOP_ONE").ConfigureAwait(false);
            response.IsSuccess.IsTrue();
        }
    }
}
