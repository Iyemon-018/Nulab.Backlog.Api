namespace Nulab.Backlog.Api
{
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
    }
}
