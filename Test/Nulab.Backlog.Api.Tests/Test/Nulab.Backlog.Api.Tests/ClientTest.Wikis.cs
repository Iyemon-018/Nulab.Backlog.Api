namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Wikis_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var parameter = new GetWikiListParameter("WEBAPITEST");
            var response  = await client.Wikis.GetListAsync(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Wikis_GetCountAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Wikis.GetCountAsync("WEBAPITEST").ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Wikis_GetTagsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Wikis.GetTagsAsync("WEBAPITEST").ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Wikis_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Wikis.GetAsync(1240765).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Wikis_GetHistoriesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var parameter = new GetWikiPageHistoriesParameter(1240765);
            var response  = await client.Wikis.GetHistories(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

    }
}