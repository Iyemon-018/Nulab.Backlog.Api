namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public interface IWikis
    {
        /// <summary>
        /// Wikiページ一覧を取得します。
        /// </summary>
        /// <param name="parameter">クエリパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-list/#
        /// </remarks>
        Task<BacklogResponse<List<WikiPage>>> GetListAsync(GetWikiListParameter parameter);

        /// <summary>
        /// Wikiページ数を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-wiki-page/#
        /// </remarks>
        Task<BacklogResponse<WikiPageCount>> GetCountAsync(string projectIdOrKey);

        /// <summary>
        /// Wikiページタグ一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-tag-list/#
        /// </remarks>
        Task<BacklogResponse<List<WikiPageTag>>> GetTagsAsync(string projectIdOrKey);
    }

    public sealed class WikiPageTag
    {
        public int id { get; set; }

        public string name { get; set; }
    }
}