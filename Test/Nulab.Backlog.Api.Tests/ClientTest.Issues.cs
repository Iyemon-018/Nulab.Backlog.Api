using System;
using System.Net;
using System.Threading.Tasks;
using Nulab.Backlog.Api.Data.Parameters;
using Xunit;

namespace Nulab.Backlog.Api.Tests
{
    public partial class ClientTest
    {
        [Fact]
        public async Task Test_シナリオ_Issues_GetListAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Issues.GetListAsync(IssuesParameter.None()).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetListAsync_パラメータ指定()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var parameter = new IssuesParameter();
            parameter.SetProjectId(new[] { 198030 });
            parameter.SetAssigneeId(new[] { 1 });
            parameter.SetAttachement(false);
            parameter.SetCategoryId(new[] { 1 });
            parameter.SetCount(100);
            parameter.SetCreatedSince(DateTime.Today);
            parameter.SetCreatedUntil(DateTime.Today);
            parameter.SetCreatedUserId(new[] { 1 });
            parameter.SetDueDateSince(DateTime.Today);
            parameter.SetDueDateUntil(DateTime.Today);
            parameter.SetId(new[] { 1 });
            parameter.SetIssueTypeId(new[] { 1 });
            parameter.SetKeyword("test");
            parameter.SetMilestoneId(new[] { 1 });
            parameter.SetOffset(0);
            parameter.SetParentChild(ParentChildCondition.All);
            parameter.SetVersionId(new[] { 1 });
            parameter.SetUpdatedUntil(DateTime.Today);
            parameter.SetUpdatedSince(DateTime.Today);
            parameter.SetStatusId(new[] { 1 });
            parameter.SetStartDateUntil(DateTime.Today);
            parameter.SetStartDateSince(DateTime.Today);
            parameter.SetSort("issueType");
            parameter.SetOrder(OrderType.Asc);
            parameter.SetSharedFile(false);
            parameter.SetResolutionId(new[] { 1 });

            // act
            var response = await client.Issues.GetListAsync(parameter).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCountAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Issues.GetCountAsync(IssuesParameter.None()).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

    }
}
