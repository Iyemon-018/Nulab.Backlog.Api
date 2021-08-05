namespace Nulab.Backlog.Api.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Notifications_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var parameter = new GetNotificationsParameter();
            var response  = await client.Notifications.GetListAsync(parameter).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Notifications_GetCountAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response  = await client.Notifications.GetCountAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

    }
}
