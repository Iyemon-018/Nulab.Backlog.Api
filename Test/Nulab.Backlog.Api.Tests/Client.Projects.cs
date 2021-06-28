namespace Nulab.Backlog.Api.Tests
{
    using System;
    using System.Linq;
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
            var client   = TestFactory.CreateClient();
            var data     = TestFactory.Load();

            // act
            var response = await client.Projects.GetUsersAsync(data.projectKey).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);

            var projectUsers = response.Content;
            _outputHelper.WriteLine(string.Join(Environment.NewLine, projectUsers.Select(x => x.ToString()).ToArray()));
        }
    }
}