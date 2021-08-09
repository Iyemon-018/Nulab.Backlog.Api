namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Parameters;
    using Data.Responses;

    public interface ITeams
    {
        /// <summary>
        /// チーム一覧を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-teams/#
        /// </remarks>
        Task<BacklogResponse<List<Team>>> GetListAsync(GetTeamsParameter parameter);
    }
}