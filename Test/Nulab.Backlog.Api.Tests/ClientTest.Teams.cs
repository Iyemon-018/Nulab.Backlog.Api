namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Teams_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var parameter = new GetTeamsParameter();
            var    response = await client.Teams.GetListAsync(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Teams_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response  = await client.Teams.GetAsync(83068).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }
    }
}
