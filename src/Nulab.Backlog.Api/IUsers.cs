namespace Nulab.Backlog.Api
{
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IUsers
    {
        /// <summary>
        /// ユーザー情報を取得します。
        /// </summary>
        /// <param name="id">ユーザーのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user/#
        /// </remarks>
        Task<BacklogResponse<User>> GetAsync(int id);

        /// <summary>
        /// 認証ユーザー情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-own-user/#
        /// </remarks>
        Task<BacklogResponse<LoginUser>> GetMySelfAsync();
    }
}