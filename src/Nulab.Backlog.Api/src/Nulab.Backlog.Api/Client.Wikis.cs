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

        /// <summary>
        /// Wikiページタグ一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-tag-list/#
        /// </remarks>
        async Task<BacklogResponse<List<WikiPageTag>>> IWikis.GetTagsAsync(string projectIdOrKey)
        {
            var parameter = QueryParameters.Build(nameof(projectIdOrKey), projectIdOrKey);
            var response  = await GetAsync($"/api/v2/wikis/tags", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<WikiPageTag>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// Wikiページ情報を取得します。
        /// </summary>
        /// <param name="wikiId">WikiページのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page/#
        /// </remarks>
        async Task<BacklogResponse<WikiPage>> IWikis.GetAsync(int wikiId)
        {
            var response  = await GetAsync($"/api/v2/wikis/{wikiId}").ConfigureAwait(false);

            return await CreateResponseAsync<WikiPage>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// Wikiページ更新履歴一覧を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-history/#
        /// </remarks>
        async Task<BacklogResponse<List<WikiPageHistory>>> IWikis.GetHistories(GetWikiPageHistoriesParameter parameter)
        {
            var response = await GetAsync($"/api/v2/wikis/{parameter.WikiId}/history", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<WikiPageHistory>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}