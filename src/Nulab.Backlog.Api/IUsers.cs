namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
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
        Task<BacklogResponse<List<RecentlyViewedIssue>>> GetRecentlyViewedIssuesAsync(string order = "", int offset = 0, int count = 20);
    }
    
    public class RecentlyViewedIssue
    {
        public Issue issue { get; set; }

        public DateTime updated { get; set; }
    }

    public class Issue
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string issueKey { get; set; }
        public int keyId { get; set; }
        public Issuetype issueType { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public object resolution { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
        public Assignee assignee { get; set; }
        public Category[] category { get; set; }
        public object[] versions { get; set; }
        public object[] milestone { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? dueDate { get; set; }
        public object estimatedHours { get; set; }
        public object actualHours { get; set; }
        public int? parentIssueId { get; set; }
        public Createduser createdUser { get; set; }
        public DateTime created { get; set; }
        public Updateduser updatedUser { get; set; }
        public DateTime updated { get; set; }
        public object[] customFields { get; set; }
        public object[] attachments { get; set; }
        public object[] sharedFiles { get; set; }
        public object[] stars { get; set; }
    }

    public class Issuetype
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int displayOrder { get; set; }
    }

    public class Priority
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int displayOrder { get; set; }
    }

    public class Assignee
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public string lang { get; set; }
        public string mailAddress { get; set; }
        public Nulabaccount nulabAccount { get; set; }
        public string keyword { get; set; }
    }

    public class Nulabaccount
    {
        public string nulabId { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
    }

    public class Createduser
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public string lang { get; set; }
        public string mailAddress { get; set; }
        public Nulabaccount1 nulabAccount { get; set; }
        public string keyword { get; set; }
    }

    public class Nulabaccount1
    {
        public string nulabId { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
    }

    public class Updateduser
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public string lang { get; set; }
        public string mailAddress { get; set; }
        public Nulabaccount2 nulabAccount { get; set; }
        public string keyword { get; set; }
    }

    public class Nulabaccount2
    {
        public string nulabId { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int displayOrder { get; set; }
    }
}