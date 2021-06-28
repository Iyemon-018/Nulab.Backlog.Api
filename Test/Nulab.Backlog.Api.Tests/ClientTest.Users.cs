namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public partial class ClientTest
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
            _outputHelper.WriteLine(response.Content.ToJson());
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetMySelfAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetMySelfAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response.Content.ToJson());
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetRecentlyViewedIssuesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetRecentlyViewedIssuesAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response.Content.ToJson());
        }
    }
}
