namespace Nulab.Backlog.Api.Data.Parameters
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developer.nulab.com/ja/docs/backlog/api/2/update-issue/#%E3%83%AA%E3%82%AF%E3%82%A8%E3%82%B9%E3%83%88%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// </remarks>
    public sealed class UpdateIssueParameter : IQueryParameter
    {
        private readonly string summary;

        private readonly int? parentIssueId;
        
        private readonly string description;
        
        private readonly int? statusId;
        
        private readonly int? resolutionId;
        
        private readonly DateTime? startDate;
        
        private readonly DateTime? dueDate;
        
        private readonly int? estimatedHours;
        
        private readonly int? actualHours;
        
        private readonly int? issueTypeId;
        
        private readonly int[] categoryId;
        
        private readonly int[] versionId;
        
        private readonly int[] milestoneId;
        
        private readonly int? priorityId;
        
        private readonly int? assigneeId;
        
        private readonly int[] notifiedUserId;
        
        private readonly int[] attachmentId;
        
        private readonly string comment;

        public UpdateIssueParameter(string summary = default
                                  , int? parentIssueId = default
                                  , string description = default
                                  , int? statusId = default
                                  , int? resolutionId = default
                                  , DateTime? startDate = default
                                  , DateTime? dueDate = default
                                  , int? estimatedHours = default
                                  , int? actualHours = default
                                  , int? issueTypeId = default
                                  , int[] categoryId = default
                                  , int[] versionId = default
                                  , int[] milestoneId = default
                                  , int? priorityId = default
                                  , int? assigneeId = default
                                  , int[] notifiedUserId = default
                                  , int[] attachmentId = default
                                  , string comment = default)
        {
            this.summary        = summary;
            this.parentIssueId  = parentIssueId;
            this.description    = description;
            this.statusId       = statusId;
            this.resolutionId   = resolutionId;
            this.startDate      = startDate;
            this.dueDate        = dueDate;
            this.estimatedHours = estimatedHours;
            this.actualHours    = actualHours;
            this.issueTypeId    = issueTypeId;
            this.categoryId     = categoryId;
            this.versionId      = versionId;
            this.milestoneId    = milestoneId;
            this.priorityId     = priorityId;
            this.assigneeId     = assigneeId;
            this.notifiedUserId = notifiedUserId;
            this.attachmentId   = attachmentId;
            this.comment        = comment;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return new QueryParameters().Add(nameof(summary), summary)
                                        .Add(nameof(issueTypeId), issueTypeId)
                                        .Add(nameof(priorityId), priorityId)
                                        .Add(nameof(parentIssueId), parentIssueId)
                                        .Add(nameof(statusId), statusId)
                                        .Add(nameof(resolutionId), resolutionId)
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
                                        .Add(nameof(attachmentId), attachmentId)
                                        .Add(nameof(comment), comment);
        }
    }
}