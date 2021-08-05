namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;
    using Extensions;

    public partial class Client : IUsers
    {
        /// <summary>
        /// ユーザー一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user-list/#
        /// </remarks>
        async Task<BacklogResponse<List<User>>> IUsers.GetListAsync()
        {
            var response = await GetAsync($"/api/v2/users").ConfigureAwait(false);
            return await CreateResponseAsync<List<User>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<User>> IUsers.GetAsync(int id)
        {
            var response = await GetAsync($"/api/v2/users/{id}").ConfigureAwait(false);
            return await CreateResponseAsync<User>(response, HttpStatusCode.OK).ConfigureAwait(false);
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
            var response = await GetAsync($"/api/v2/users/myself").ConfigureAwait(false);
            return await CreateResponseAsync<LoginUser>(response, HttpStatusCode.OK).ConfigureAwait(false);
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
        async Task<BacklogResponse<List<RecentlyViewedIssue>>> IUsers.GetRecentlyViewedIssuesAsync(string order
                                                                                                 , int? offset
                                                                                                 , int? count)
        {
            var parameters = QueryParameters.Build(nameof(order), order)
                                            .Add(nameof(offset), offset)
                                            .Add(nameof(count), count);
            var response = await GetAsync($"/api/v2/users/myself/recentlyViewedIssues", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<List<RecentlyViewedIssue>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<UserActivity>>> IUsers.GetActivitiesAsync(int userId, int[] activityTypeId, int? minId, int? maxId, int? count, string order)
        {
            var parameters = QueryParameters.Build(nameof(activityTypeId), activityTypeId)
                                            .Add(nameof(minId), minId)
                                            .Add(nameof(maxId), maxId)
                                            .Add(nameof(count), count)
                                            .Add(nameof(order), order);
            var response = await GetAsync($"/api/v2/users/{userId}/activities", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<List<UserActivity>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<Star>>> IUsers.GetStarsAsync(int userId, int? minId, int? maxId, int? count, string order)
        {
            var parameters = QueryParameters.Build(nameof(minId), minId)
                                            .Add(nameof(maxId), maxId)
                                            .Add(nameof(count), count)
                                            .Add(nameof(order), order);
            var response = await GetAsync($"/api/v2/users/{userId}/stars", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<List<Star>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<StarsCount>> IUsers.GetStarsCountAsync(int userId, DateTime? since, DateTime? until)
        {
            var parameters = QueryParameters.Build(nameof(since), since.AsDateValue())
                                            .Add(nameof(until), until.AsDateValue());
            var response = await GetAsync($"/api/v2/users/{userId}/stars/count", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<StarsCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<RecentlyViewedProject>>> IUsers.GetRecentlyViewedProjectsAsync(string order, int? offset, int? count)
        {
            var parameters = QueryParameters.Build(nameof(order), order)
                                            .Add(nameof(offset), offset)
                                            .Add(nameof(count), count);
            var response = await GetAsync($"/api/v2/users/myself/recentlyViewedProjects", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<List<RecentlyViewedProject>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        async Task<BacklogResponse<List<RecentlyViewedWiki>>> IUsers.GetRecentlyViewedWikisAsync(string order, int? offset, int? count)
        {
            var parameters = QueryParameters.Build(nameof(order), order)
                                            .Add(nameof(offset), offset)
                                            .Add(nameof(count), count);
            var response = await GetAsync($"/api/v2/users/myself/recentlyViewedWikis", parameters).ConfigureAwait(false);

            return await CreateResponseAsync<List<RecentlyViewedWiki>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// ウォッチ一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-watching-list/
        /// </remarks>
        async Task<BacklogResponse<List<Watching>>> IUsers.GetWatchingsAsync(GetWatchingsParameter parameter)
        {
            var response = await GetAsync($"/api/v2/users/{parameter.UserId}/watchings", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<List<Watching>>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }

        /// <summary>
        /// ウォッチ数を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/count-watching/#
        /// </remarks>
        async Task<BacklogResponse<WatchingCount>> IUsers.GetWatchingCountAsync(GetWatchingCountParameter parameter)
        {
            var response = await GetAsync($"/api/v2/users/{parameter.UserId}/watchings/count", parameter).ConfigureAwait(false);

            return await CreateResponseAsync<WatchingCount>(response, HttpStatusCode.OK).ConfigureAwait(false);
        }
    }
}
