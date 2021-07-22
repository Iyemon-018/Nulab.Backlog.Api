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
            var response = await client.Issues.GetListAsync(GetIssuesParameter.None()).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetListAsync_パラメータ指定()
        {
            // arrange
            var client = TestFactory.CreateClient();
            var parameter = new GetIssuesParameter();
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
            var response = await client.Issues.GetCountAsync(GetIssuesParameter.None()).ConfigureAwait(false);

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

        //[Fact]
        public async Task Test_シナリオ_Issues_作成と更新と削除()
        {
            // このテストは実行するたびに課題キーがインクリメントされるので頻繁に実行したくない。
            // arrange
            var client = TestFactory.CreateClient();

            // act
            var parameter = new AddIssueParameter(198030, $"テスト課題です<{nameof(Test_シナリオ_Issues_作成と更新と削除)}: {DateTime.Now:yyyy/MM/dd HH:mm:ss}>", 953273, 3);
            var response  = await client.Issues.AddAsync(parameter).ConfigureAwait(false);

            // assert
            // create
            response.StatusCode.Is(HttpStatusCode.Created);
            _outputHelper.WriteLine("[AddAsync]");
            _outputHelper.WriteLine(response);

            var issue = response.Content;

            // update
            var updateParameter = new UpdateIssueParameter($"テスト課題を更新しました。<{nameof(Test_シナリオ_Issues_作成と更新と削除)}: {DateTime.Now:yyyy/MM/dd HH:mm:ss}>");
            response = await client.Issues.UpdateAsync(issue.issueKey, updateParameter).ConfigureAwait(false);

            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine("[UpdateAsync]");
            _outputHelper.WriteLine(response);

            // dispose
            response = await client.Issues.DeleteAsync(issue.issueKey).ConfigureAwait(false);

            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine("[DeleteAsync]");
            _outputHelper.WriteLine(response);
        }

        //[Fact]
        public async Task Test_シナリオ_Issues_Comment_作成と更新と削除()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            // add
            var parameter = new AddCommentParameter($"`Nulab.Backlog.Api` からコメントを追加しました。<{nameof(Test_シナリオ_Issues_Comment_作成と更新と削除)}: {DateTime.Now:yyyy/MM/dd HH:mm:ss}>");
            var response = await client.Issues.AddCommentAsync("WEBAPITEST-1", parameter).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.Created);
            _outputHelper.WriteLine($"[{nameof(client.Issues.AddCommentAsync)}]");
            _outputHelper.WriteLine(response);

            var comment = response.Content;

            // update
            var updateParameter = new UpdateIssueCommentParameter($"`Nulab.Backlog.Api` からコメントを更新しました。<{nameof(Test_シナリオ_Issues_Comment_作成と更新と削除)}: {DateTime.Now:yyyy/MM/dd HH:mm:ss}>");
            response = await client.Issues.UpdateCommentAsync("WEBAPITEST-1", comment.id, updateParameter).ConfigureAwait(false);

            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine($"{Environment.NewLine}[{nameof(client.Issues.UpdateCommentAsync)}]");
            _outputHelper.WriteLine(response);

            // delete
            response = await client.Issues.DeleteCommentAsync("WEBAPITEST-1", comment.id).ConfigureAwait(false);

            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine($"{Environment.NewLine}[{nameof(client.Issues.DeleteCommentAsync)}]");
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCommentCountAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Issues.GetCommentCountAsync("WEBAPITEST-1").ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCommentAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Issues.GetCommentAsync("WEBAPITEST-1", 87901123).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetCommentNotificationsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Issues.GetCommentNotificationsAsync("WEBAPITEST-1", 89623485).ConfigureAwait(false);

            // assert
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }


    }
}
