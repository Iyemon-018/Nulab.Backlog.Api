using System;
using System.Collections.Generic;
using System.Text;

namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public partial class Client
    {
        [Fact]
        public async Task Test_シナリオ_Users_GetAsync()
        {
            // arrange
            var client         = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);

            // act
            var response   = await client.Users.GetAsync(mySelfResponse.Content.id).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);

            var user = response.Content;
            _outputHelper.WriteLine(user.ToString());
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetMySelfAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetMySelfAsync();

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);

            var loginUser = response.Content;
            _outputHelper.WriteLine(loginUser.ToString());
        }
    }
}
