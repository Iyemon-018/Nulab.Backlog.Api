namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IConfigurations
    {
        /// <summary>
        /// 優先度一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-priority-list/#
        /// </remarks>
        Task<BacklogResponse<List<Priority>>> GetPrioritiesAsync();

        /// <summary>
        /// 完了理由一覧を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-resolution-list/#
        /// </remarks>
        Task<BacklogResponse<List<Resolution>>> GetResolutionsAsync();
    }
}