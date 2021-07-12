namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Configurations_GetPrioritiesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Configurations.GetPrioritiesAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Configurations_GetResolutionsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Configurations.GetResolutionsAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }
    }
}
