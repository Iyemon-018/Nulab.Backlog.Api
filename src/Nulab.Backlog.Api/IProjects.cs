﻿namespace Nulab.Backlog.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IProjects
    {
        /// <summary>
        /// プロジェクト一覧を取得します。
        /// </summary>
        /// <param name="archived">省略された場合は全てのプロジェクト、falseの場合はアーカイブされていないプロジェクト、trueの場合はアーカイブされたプロジェクトを返します。</param>
        /// <param name="all">ユーザが管理者権限の場合のみ有効なパラメータです。trueの場合はすべてのプロジェクト、falseの場合は参加しているプロジェクトのみを返します。初期値はfalse。</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-list/#
        /// </remarks>
        Task<BacklogResponse<List<Project>>> GetAsync(bool? archived = null, bool? all = null);

        /// <summary>
        /// プロジェクトユーザー一覧を取得します。
        /// </summary>
        /// <param name="projectIdOrKey">プロジェクトのID または プロジェクトキー</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-project-user-list/#
        /// </remarks>
        Task<BacklogResponse<List<ProjectUser>>> GetUsersAsync(string projectIdOrKey, bool? excludeGroupMembers = null);
    }
}