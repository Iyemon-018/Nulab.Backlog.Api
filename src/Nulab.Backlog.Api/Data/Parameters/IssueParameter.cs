namespace Nulab.Backlog.Api.Data.Parameters
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/add-issue/#%E3%83%AA%E3%82%AF%E3%82%A8%E3%82%B9%E3%83%88%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public sealed class IssueParameter : IQueryParameter
    {
        private int projectId;

        private string summary;
        
        private int? parentIssueId;
        
        private string description;
        
        private DateTime? startDate;
        
        private DateTime? dueDate;
        
        private int? estimatedHours;
        
        private int issueTypeId;
        
        private int priorityId;
        
        private int? actualHours;
        
        private int[] categoryId;
        
        private int[] versionId;
        
        private int[] milestoneId;
        
        private int? assigneeId;
        
        private int[] notifiedUserId;
        
        private int[] attachmentId;

        public IssueParameter(int projectId
                            , string summary
                            , int issueTypeId
                            , int priorityId
                            , int? parentIssueId = default
                            , string description = default
                            , DateTime? startDate = default
                            , DateTime? dueDate = default
                            , int? estimatedHours = default
                            , int? actualHours = default
                            , int[] categoryId = default
                            , int[] versionId = default
                            , int[] milestoneId = default
                            , int? assigneeId = default
                            , int[] notifiedUserId = default
                            , int[] attachmentId = default)
        {
            this.projectId      = projectId;
            this.summary        = summary;
            this.issueTypeId    = issueTypeId;
            this.priorityId     = priorityId;
            this.parentIssueId  = parentIssueId;
            this.description    = description;
            this.startDate      = startDate;
            this.dueDate        = dueDate;
            this.estimatedHours = estimatedHours;
            this.actualHours    = actualHours;
            this.categoryId     = categoryId;
            this.versionId      = versionId;
            this.milestoneId    = milestoneId;
            this.assigneeId     = assigneeId;
            this.notifiedUserId = notifiedUserId;
            this.attachmentId   = attachmentId;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return new QueryParameters().Add(nameof(projectId), projectId)
                                        .Add(nameof(summary), summary)
                                        .Add(nameof(issueTypeId), issueTypeId)
                                        .Add(nameof(priorityId), priorityId)
                                        .Add(nameof(parentIssueId), parentIssueId)
                                        .Add(nameof(description), description)
                                        .Add(nameof(startDate), startDate)
                                        .Add(nameof(dueDate), dueDate)
                                        .Add(nameof(estimatedHours), estimatedHours)
                                        .Add(nameof(actualHours), actualHours)
                                        .Add(nameof(categoryId), categoryId)
                                        .Add(nameof(versionId), versionId)
                                        .Add(nameof(milestoneId), milestoneId)
                                        .Add(nameof(assigneeId), assigneeId)
                                        .Add(nameof(notifiedUserId), notifiedUserId)
                                        .Add(nameof(attachmentId), attachmentId);
        }
    }
}