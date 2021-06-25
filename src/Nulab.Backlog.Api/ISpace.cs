namespace Nulab.Backlog.Api
{
    using System.Threading.Tasks;
    using Data.Responses;

    public interface ISpace
    {
        /// <summary>
        /// スペース情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-space/#
        /// </remarks>
        Task<BacklogResponse<Space>> GetAsync();
    }
}