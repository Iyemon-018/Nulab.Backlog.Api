namespace Nulab.Backlog.Api
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-comment-notifications/#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9%E8%AA%AC%E6%98%8E
    /// </remarks>
    public enum NotificationReasonType
    {
        Assigned = 1,
        Commented = 2,
        Add = 3,
        Updated = 4,
        AddFile = 5,
        AddUser = 6,
        Other = 9,
        AssignedPullRequest = 10,
        CommentedPullRequest = 11,
        AddPullRequest = 12,
        UpdatedPullRequest = 13,
    }
}