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
    }
}