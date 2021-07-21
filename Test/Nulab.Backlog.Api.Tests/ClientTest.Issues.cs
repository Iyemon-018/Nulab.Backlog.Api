namespace Nulab.Backlog.Api.Tests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Xunit;

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

        [Fact]
        public async Task Test_シナリオ_Issues_GetAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Issues.GetAsync("WEBAPITEST-1").ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCommentsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var response = await client.Issues.GetCommentsAsync("WEBAPITEST-1").ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCommentsAsync_パラメータ指定あり()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var parameter = new CommentParameter(0, 99999999, 10, OrderType.Asc);

            // act
            var response = await client.Issues.GetCommentsAsync("WEBAPITEST-1", parameter).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact(Skip = "このテストはローカル開発環境以外では実行したくない。")]
        public async Task Test_シナリオ_Issues_作成と更新と削除()
        {
            // このテストは実行するたびに課題キーがインクリメントされるので頻繁に実行したくない。
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var parameter = new IssueParameter(198030, $"テスト課題です<{nameof(Test_シナリオ_Issues_作成と更新と削除)}: {DateTime.Now:yyyy/MM/dd HH:mm:ss}>", 953273, 3);
            var response  = await client.Issues.PostAsync(parameter).ConfigureAwait(false);

            // assert
            // create
            response.StatusCode.Is(HttpStatusCode.Created);
            _outputHelper.WriteLine("[PostAsync]");
            _outputHelper.WriteLine(response);

            // dispose
            response = await client.Issues.DeleteAsync(response.Content.issueKey).ConfigureAwait(false);

            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine("[DeleteAsync]");
            _outputHelper.WriteLine(response);
        }

    }
}
