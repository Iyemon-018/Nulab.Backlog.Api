namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
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
            _outputHelper.WriteLine(response.Content.ToJson());
        }
    }
}
