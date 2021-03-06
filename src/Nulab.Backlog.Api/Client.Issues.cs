namespace Nulab.Backlog.Api
{
    using System.Net;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public partial class Client : IIssues
    {
        async Task<BacklogResponse<List<Issue>>> IIssues.GetListAsync(GetIssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Issue>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<IssueCount>> IIssues.GetCountAsync(GetIssuesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/count", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<IssueCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.GetAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<Issue>> IIssues.AddAsync(AddIssueParameter parameter)
        {
            var response = await PostAsync($"/api/v2/issues", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.Created).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題情報を更新します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">追加する課題の情報</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-issue/#
        /// </remarks>
        async Task<BacklogResponse<Issue>> IIssues.UpdateAsync(string issueIdOrKey
                                                             , UpdateIssueParameter parameter)
        {
            var response = await PatchAsync($"/api/v2/issues/{issueIdOrKey}", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題を削除します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue/#
        /// </remarks>
        async Task<BacklogResponse<Issue>> IIssues.DeleteAsync(string issueIdOrKey)
        {
            var response = await DeleteAsync($"/api/v2/issues/{issueIdOrKey}").ConfigureAwait(false);

            return await CreateResponseAsync<Issue>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Comment>>> IIssues.GetCommentsAsync(string issueIdOrKey, CommentParameter parameter)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Comment>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメントを追加します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">追加するコメントの情報</param>
        /// <returns></returns>
        async Task<BacklogResponse<Comment>> IIssues.AddCommentAsync(string issueIdOrKey
                                                                   , AddCommentParameter parameter)
        {
            var response = await PostAsync($"/api/v2/issues/{issueIdOrKey}/comments", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<Comment>(response, HttpStatusCode.Created).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメント数を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-comment/#
        /// </remarks>
        async Task<BacklogResponse<CommentCount>> IIssues.GetCommentCountAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments/count").ConfigureAwait(false);

            return await CreateResponseAsync<CommentCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメント情報を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-comment/#
        /// </remarks>
        async Task<BacklogResponse<Comment>> IIssues.GetCommentAsync(string issueIdOrKey
                                                                   , int commentId)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments/{commentId}").ConfigureAwait(false);

            return await CreateResponseAsync<Comment>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメントを削除する。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/delete-comment/#
        /// </remarks>
        async Task<BacklogResponse<Comment>> IIssues.DeleteCommentAsync(string issueIdOrKey
                                                                      , int commentId)
        {
            var response = await DeleteAsync($"/api/v2/issues/{issueIdOrKey}/comments/{commentId}").ConfigureAwait(false);

            return await CreateResponseAsync<Comment>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメント情報を更新します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <param name="parameter">コメントの更新パラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-comment/#
        /// </remarks>
        async Task<BacklogResponse<Comment>> IIssues.UpdateCommentAsync(string issueIdOrKey
                                                                      , int commentId
                                                                      , UpdateIssueCommentParameter parameter)
        {
            var response = await PatchAsync($"/api/v2/issues/{issueIdOrKey}/comments/{commentId}", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<Comment>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメントのお知らせ一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-comment-notifications/#
        /// </remarks>
        async Task<BacklogResponse<List<CommentNotification>>> IIssues.GetCommentNotificationsAsync(string issueIdOrKey
                                                                                                  , int commentId)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/comments/{commentId}/notifications").ConfigureAwait(false);

            return await CreateResponseAsync<List<CommentNotification>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題コメントにお知らせを追加します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <param name="parameter">お知らせを追加するためのパラメータ</param>
        /// <returns></returns>
        async Task<BacklogResponse<CommentNotification>> IIssues.AddCommentNotificationAsync(string issueIdOrKey
                                                                                           , int commentId
                                                                                           , AddCommentNotificationParameter parameter)
        {
            var response = await PostAsync($"/api/v2/issues/{issueIdOrKey}/comments/{commentId}/notifications", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<CommentNotification>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題の参加者一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-participant-list/#
        /// </remarks>
        async Task<BacklogResponse<List<User>>> IIssues.GetParticipantsAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/participants").ConfigureAwait(false);

            return await CreateResponseAsync<List<User>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// 課題共有ファイル一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-linked-shared-files/#
        /// </remarks>
        async Task<BacklogResponse<List<SharedFile>>> IIssues.GetSharedFilesAsync(string issueIdOrKey)
        {
            var response = await GetAsync($"/api/v2/issues/{issueIdOrKey}/sharedFiles").ConfigureAwait(false);

            return await CreateResponseAsync<List<SharedFile>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}