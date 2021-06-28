namespace Nulab.Backlog.Api.Tests
{
    using System.Threading.Tasks;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public async Task Test_シナリオ()
        {
            var client   = TestFactory.CreateClient();
            var response = await client.Projects.GetUsersAsync("DEVELOP_ONE").ConfigureAwait(false);
            response.IsSuccess.IsTrue();
        }
    }
}