namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Responses;

    public partial class Client : IUsers
    {
        async Task<BacklogResponse<User>> IUsers.GetAsync(int id)
        {
            var response = await GetAsync($"/api/v2/users/{id}");
            return await CreateResponseAsync<User>(response, HttpStatusCode.OK);
        }

        /// <summary>
        /// 認証ユーザー情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-own-user/#
        /// </remarks>
        async Task<BacklogResponse<LoginUser>> IUsers.GetMySelfAsync()
        {
            var response = await GetAsync($"/api/v2/users/myself");
            return await CreateResponseAsync<LoginUser>(response, HttpStatusCode.OK);
        }

        /// <summary>
        /// 自分が最近見た課題一覧を取得します。
        /// </summary>
        /// <param name="order">“asc”または”desc” 指定が無い場合は”desc”</param>
        /// <param name="offset"></param>
        /// <param name="count">取得上限(1-100) 指定が無い場合は20</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-issues/#
        /// </remarks>
        async Task<BacklogResponse<List<RecentlyViewedIssue>>> IUsers.GetRecentlyViewedIssuesAsync(string order = ""
                                                                                                 , int offset = 0
                                                                                                 , int count = 20)
        {
            var parameters = QueryParameters.Build(nameof(order), order)
                                            .Add(nameof(offset), offset)
                                            .Add(nameof(count), count);
            var response = await GetAsync($"/api/v2/users/myself/recentlyViewedIssues", parameters);

            return await CreateResponseAsync<List<RecentlyViewedIssue>>(response, HttpStatusCode.OK);
        }
    }
}
