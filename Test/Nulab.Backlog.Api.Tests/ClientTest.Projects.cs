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
        public async Task Test_シナリオ_Projects_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetListAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetListAsync_アーカイブされたプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetListAsync(archived: true).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetListAsync_アーカイブされていないプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetListAsync(archived: false).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetListAsync_管理者権限が有効なすべてのプロジェクト()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act 
            var response = await client.Projects.GetListAsync(all: true).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetStatuesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetStatuesAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetAdministratorsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetAdministratorsAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetIssueTypesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetIssueTypesAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetCategoriesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetCategoriesAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetVersionsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetVersionsAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Projects_GetCustomFieldsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var data = TestFactory.Load();

            // act
            var response = await client.Projects.GetCustomFieldsAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

    }
}