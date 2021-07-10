namespace Nulab.Backlog.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_GetPrioritiesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.GetPrioritiesAsync().ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }
    }
}
