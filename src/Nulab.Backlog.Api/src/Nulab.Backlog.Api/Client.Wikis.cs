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
    }
}