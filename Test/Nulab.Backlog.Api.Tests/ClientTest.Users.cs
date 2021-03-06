namespace Nulab.Backlog.Api.Tests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Users_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetListAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetAsync()
        {
            // arrange
            var client         = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response   = await client.Users.GetAsync(mySelfResponse.Content.id).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetMySelfAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetMySelfAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetRecentlyViewedIssuesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetRecentlyViewedIssuesAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetActivitiesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetActivitiesAsync(mySelfResponse.Content.id).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetActivitiesAsync_パラメータ指定あり()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetActivitiesAsync(mySelfResponse.Content.id
                                                                , activityTypeId: new[] { 1, 15 }
                                                                , minId: 0
                                                                , maxId: 999999999
                                                                , count: 30
                                                                , order: "asc").ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetStarsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetStarsAsync(mySelfResponse.Content.id).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetStarsAsync_パラメータ指定あり()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetStarsAsync(mySelfResponse.Content.id
                                                          , minId: 0
                                                          , maxId: 999999999
                                                          , count: 30
                                                          , order: "asc")
                                                        .ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetStarsCountAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetStarsCountAsync(mySelfResponse.Content.id).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetStarsCountAsync_パラメータ指定あり()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var response = await client.Users.GetStarsCountAsync(mySelfResponse.Content.id
                                                               , new DateTime(2021, 7, 1)
                                                               , new DateTime(2030, 12, 31)).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetRecentlyViewedProjectsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetRecentlyViewedProjectsAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetRecentlyViewedWikisAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetRecentlyViewedWikisAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetWatchingsAsync()
        {
            // arrange
            var client         = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var parameter = new GetWatchingsParameter(mySelfResponse.Content.id);
            var response  = await client.Users.GetWatchingsAsync(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetWatchingCountAsync()
        {
            // arrange
            var client         = TestFactory.CreateClient();
            var mySelfResponse = await client.Users.GetMySelfAsync().ConfigureAwait(false);
            TestFactory.UpdateRateLimiting(mySelfResponse.RateLimiting);

            // act
            var parameter = new GetWatchingCountParameter(mySelfResponse.Content.id);
            var response  = await client.Users.GetWatchingCountAsync(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetWatchingAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetWatchingAsync(363658).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Users_GetRateLimitAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Users.GetRateLimitAsync().ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

    }
}
