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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetListAsync_パラメータ指定()
        {
            // arrange
            var client    = TestFactory.CreateClient();
            var parameter = new GetIssuesParameter(projectId: new[] {198030}
                                                 , assigneeId: new[] {1}
                                                 , attachment: false
                                                 , categoryId: new[] {1}
                                                 , count: 100
                                                 , createdSince: DateTime.Today
                                                 , createdUntil: DateTime.Today
                                                 , createdUserId: new[] {1}
                                                 , dueDateSince: DateTime.Today
                                                 , dueDateUntil: DateTime.Today
                                                 , id: new[] {1}
                                                 , issueTypeId: new[] {1}
                                                 , keyword: "test"
                                                 , milestoneId: new[] {1}
                                                 , offset: 0
                                                 , parentChild: ParentChildCondition.All
                                                 , versionId: new[] {1}, updatedSince: DateTime.Today
                                                 , updatedUntil: DateTime.Today
                                                 , statusId: new[] {1}
                                                 , startDateUntil: DateTime.Today
                                                 , startDateSince: DateTime.Today
                                                 , sort: "issueType"
                                                 , order: OrderType.Asc
                                                 , sharedFile: false
                                                 , resolutionId: new[] {1});

            // act
            var response = await client.Issues.GetListAsync(parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
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
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        //[Fact]
        public async Task Test_シナリオ_Issues_AddCommentNotificationAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var parameter = new AddCommentNotificationParameter(new []{ 531310 });
            var response  = await client.Issues.AddCommentNotificationAsync("WEBAPITEST-1", 87901123, parameter).ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetParticipantsAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Issues.GetParticipantsAsync("WEBAPITEST-1").ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }

        [Fact]
        public async Task Test_シナリオ_Issues_GetSharedFilesAsync()
        {
            // arrange
            var client = TestFactory.CreateClient();

            // arrange
            var response = await client.Issues.GetSharedFilesAsync("WEBAPITEST-1").ConfigureAwait(false);

            // assert
            TestFactory.UpdateRateLimiting(response.RateLimiting);
            response.StatusCode.Is(HttpStatusCode.OK);
            _outputHelper.WriteLine(response);
        }




    }
}
