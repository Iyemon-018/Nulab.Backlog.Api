namespace Nulab.Backlog.Api.Tests
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Space_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Space.GetAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Space_Activities_GetActivitiesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Space.GetActivitiesAsync(new []{1,5,12}).ConfigureAwait(false);

            // assert
            response.AsErrorMessages().ToArray().IsNullOrEmpty();
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Space_GetNotificationAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Space.GetNotificationAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }
    }
}
