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
        Task<BacklogResponse<Issue>> UpdateAsync(string issueIdOrKey, UpdateIssueParameter parameter);

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
        Task<BacklogResponse<List<Comment>>> GetCommentsAsync(string issueIdOrKey, CommentParameter parameter = null);

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
        /// <param name="commendId">コメントのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-comment/#
        /// </remarks>
        Task<BacklogResponse<Comment>> GetCommentAsync(string issueIdOrKey, int commendId);

        //Task<BacklogResponse<Comment>> DeleteCommentAsync(string issueIdOrKey
        //                                                , int commentId);

        //Task<BacklogResponse<Comment>> UpdateCommentAsync(string issueIdOrKey
        //                                                , int commentId);
    }
}