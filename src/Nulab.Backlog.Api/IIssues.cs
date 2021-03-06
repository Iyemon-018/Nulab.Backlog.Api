namespace Nulab.Backlog.Api
{
    using Data.Parameters;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IIssues
    {
        /// <summary>
        /// 課題一覧を取得します。
        /// </summary>
        /// <param name="parameter">クエリパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-list/#
        /// </remarks>
        Task<BacklogResponse<List<Issue>>> GetListAsync(GetIssuesParameter parameter);

        /// <summary>
        /// 課題数を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-issue/#
        /// </remarks>
        Task<BacklogResponse<IssueCount>> GetCountAsync(GetIssuesParameter parameter);

        /// <summary>
        /// 課題情報を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue/#
        /// </remarks>
        Task<BacklogResponse<Issue>> GetAsync(string issueIdOrKey);

        /// <summary>
        /// 課題を追加します。
        /// </summary>
        /// <param name="parameter">追加する課題の情報</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/add-issue/#
        /// </remarks>
        Task<BacklogResponse<Issue>> AddAsync(AddIssueParameter parameter);

        /// <summary>
        /// 課題情報を更新します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">追加する課題の情報</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/update-issue/#
        /// </remarks>
        Task<BacklogResponse<Issue>> UpdateAsync(string issueIdOrKey
                                               , UpdateIssueParameter parameter);

        /// <summary>
        /// 課題を削除します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue/#
        /// </remarks>
        Task<BacklogResponse<Issue>> DeleteAsync(string issueIdOrKey);

        /// <summary>
        /// 課題コメントを取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">クエリパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-comment-list/#
        /// </remarks>
        Task<BacklogResponse<List<Comment>>> GetCommentsAsync(string issueIdOrKey
                                                            , CommentParameter parameter = null);

        /// <summary>
        /// 課題コメントを追加します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="parameter">追加するコメントの情報</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/add-comment/#
        /// </remarks>
        Task<BacklogResponse<Comment>> AddCommentAsync(string issueIdOrKey
                                                     , AddCommentParameter parameter);

        /// <summary>
        /// 課題コメント数を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-comment/#
        /// </remarks>
        Task<BacklogResponse<CommentCount>> GetCommentCountAsync(string issueIdOrKey);

        /// <summary>
        /// 課題コメント情報を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-comment/#
        /// </remarks>
        Task<BacklogResponse<Comment>> GetCommentAsync(string issueIdOrKey
                                                     , int commentId);

        /// <summary>
        /// 課題コメントを削除する。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/delete-comment/#
        /// </remarks>
        Task<BacklogResponse<Comment>> DeleteCommentAsync(string issueIdOrKey
                                                        , int commentId);

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
        Task<BacklogResponse<Comment>> UpdateCommentAsync(string issueIdOrKey
                                                        , int commentId
                                                        , UpdateIssueCommentParameter parameter);

        /// <summary>
        /// 課題コメントのお知らせ一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-comment-notifications/#
        /// </remarks>
        Task<BacklogResponse<List<CommentNotification>>> GetCommentNotificationsAsync(string issueIdOrKey
                                                                                    , int commentId);

        /// <summary>
        /// 課題コメントにお知らせを追加します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <param name="commentId">コメントのID</param>
        /// <param name="parameter">お知らせを追加するためのパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/add-comment-notification/#url
        /// </remarks>
        Task<BacklogResponse<CommentNotification>> AddCommentNotificationAsync(string issueIdOrKey
                                                                             , int commentId
                                                                             , AddCommentNotificationParameter parameter);

        /// <summary>
        /// 課題の参加者一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-participant-list/#
        /// </remarks>
        Task<BacklogResponse<List<User>>> GetParticipantsAsync(string issueIdOrKey);

        /// <summary>
        /// 課題共有ファイル一覧を取得します。
        /// </summary>
        /// <param name="issueIdOrKey">課題のID または 課題キー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-linked-shared-files/#
        /// </remarks>
        Task<BacklogResponse<List<SharedFile>>> GetSharedFilesAsync(string issueIdOrKey);
    }
}