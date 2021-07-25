namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    partial class Client : IWikis
    {
        /// <summary>
        /// Wikiページ一覧を取得します。
        /// </summary>
        /// <param name="parameter">クエリパラメータ</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-list/#
        /// </remarks>
        async Task<BacklogResponse<List<WikiPage>>> IWikis.GetListAsync(GetWikiListParameter parameter)
        {
            var response  = await GetAsync($"/api/v2/wikis", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<WikiPage>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// Wikiページ数を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-wiki-page/#
        /// </remarks>
        async Task<BacklogResponse<WikiPageCount>> IWikis.GetCountAsync(string projectIdOrKey)
        {
            var parameter = QueryParameters.Build(nameof(projectIdOrKey), projectIdOrKey);
            var response  = await GetAsync($"/api/v2/wikis/count", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<WikiPageCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}