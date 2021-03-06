namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IProjects
    {
        /// <summary>
        /// プロジェクトの状態一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトID もしくは　プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-status-list-of-project/#
        /// </remarks>
        Task<BacklogResponse<List<ProjectStatus>>> GetStatuesAsync(string projectIdOrKey);

        /// <summary>
        /// プロジェクト一覧を取得します。
        /// </summary>
        /// <param name="archived">省略された場合は全てのプロジェクト、falseの場合はアーカイブされていないプロジェクト、trueの場合はアーカイブされたプロジェクトを返します。</param>
        /// <param name="all">ユーザが管理者権限の場合のみ有効なパラメータです。trueの場合はすべてのプロジェクト、falseの場合は参加しているプロジェクトのみを返します。初期値はfalse。</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-list/#
        /// </remarks>
        Task<BacklogResponse<List<Project>>> GetListAsync(bool? archived = null, bool? all = null);

        /// <summary>
        /// プロジェクト情報を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project/#
        /// </remarks>
        Task<BacklogResponse<Project>> GetAsync(string projectIdOrKey);

        /// <summary>
        /// プロジェクトユーザー一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-user-list/#
        /// </remarks>
        Task<BacklogResponse<List<ProjectUser>>> GetUsersAsync(string projectIdOrKey, bool? excludeGroupMembers = null);

        /// <summary>
        /// プロジェクト管理者一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-project-administrators/#
        /// </remarks>
        Task<BacklogResponse<List<User>>> GetAdministratorsAsync(string projectIdOrKey);

        /// <summary>
        /// 種別一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-type-list/#
        /// </remarks>
        Task<BacklogResponse<List<IssueType>>> GetIssueTypesAsync(string projectIdOrKey);

        /// <summary>
        /// カテゴリー一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-category-list/#
        /// </remarks>
        Task<BacklogResponse<List<Category>>> GetCategoriesAsync(string projectIdOrKey);

        /// <summary>
        /// バージョン(マイルストーン)一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-version-milestone-list/#
        /// </remarks>
        Task<BacklogResponse<List<ProjectVersion>>> GetVersionsAsync(string projectIdOrKey);

        /// <summary>
        /// カスタム属性一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-custom-field-list/#
        /// </remarks>
        Task<BacklogResponse<List<CustomField>>> GetCustomFieldsAsync(string projectIdOrKey);

        /// <summary>
        /// 共有ファイル一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <param name="path">ディレクトリのパス</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-shared-files/#
        /// </remarks>
        Task<BacklogResponse<List<SharedFile>>> GetFilesAsync(string projectIdOrKey, string path);

        /// <summary>
        /// 共有ファイルをダウンロードします。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-file/#
        /// </remarks>
        Task<BacklogResponse<ContentFile>> GetFileContentAsync(string projectIdOrKey, int id);

        /// <summary>
        /// プロジェクトの容量使用状況を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-disk-usage/#
        /// </remarks>
        Task<BacklogResponse<DiskUsage>> GetDiskUsageAsync(string projectIdOrKey);

        /// <summary>
        /// Webhook一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-webhooks/#
        /// </remarks>
        Task<BacklogResponse<List<Webhook>>> GetWebHooksAsync(string projectIdOrKey);

        /// <summary>
        /// プロジェクトチーム一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-team-list/#
        /// </remarks>
        Task<BacklogResponse<List<Team>>> GetTeamsAsync(string projectIdOrKey);
    }
}