namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    public partial class ClientTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public ClientTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetUsersAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data   = TestFactory.Load();

            // act
            var response = await client.Projects.GetUsersAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAsync_アーカイブされたプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetAsync(archived: true).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAsync_アーカイブされていないプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetAsync(archived: false).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAsync_管理者権限が有効なすべてのプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetAsync(all: true).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }
    }
}