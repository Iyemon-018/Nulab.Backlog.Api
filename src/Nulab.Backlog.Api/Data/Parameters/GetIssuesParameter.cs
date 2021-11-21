namespace Nulab.Backlog.Api.Data.Parameters
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// GET: https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-list/#%E3%82%AF%E3%82%A8%E3%83%AA%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
    /// 必須パラメータ: なし
    /// </remarks>
    public sealed class GetIssuesParameter : IQueryParameter
    {
        private int[] assigneeId;

        private bool? attachment;

        private int[] categoryId;

        private int? count;

        private DateTime? createdSince;

        private DateTime? createdUntil;

        private int[] createdUserId;

        private DateTime? dueDateSince;
        
        private DateTime? dueDateUntil;
        
        private int[] id;

        private int[] issueTypeId;
        
        private string keyword;

        private int[] milestoneId;

        private int? offset;

        private OrderType? order;

        private ParentChildCondition? parentChild;
        
        private int[] parentIssueId;

        private int[] priorityId;
        
        private int[] projectId;

        private int[] resolutionId;

        private bool? sharedFile;

        private string sort;
        
        private DateTime? startDateSince;
        
        private DateTime? startDateUntil;

        private int[] statusId;
        
        private DateTime? updatedSince;
        
        private DateTime? updatedUntil;

        private int[] versionId;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetIssuesParameter(int[] assigneeId = null
                                , bool? attachment = default
                                , int[] categoryId = null
                                , int? count = default
                                , DateTime? createdSince = default
                                , DateTime? createdUntil = default
                                , int[] createdUserId = null
                                , DateTime? dueDateSince = default
                                , DateTime? dueDateUntil = default
                                , int[] id = null
                                , int[] issueTypeId = null
                                , string keyword = null
                                , int[] milestoneId = null
                                , int? offset = default
                                , OrderType? order = default
                                , ParentChildCondition? parentChild = default
                                , int[] parentIssueId = null
                                , int[] priorityId = null
                                , int[] projectId = null
                                , int[] resolutionId = null
                                , bool? sharedFile = default
                                , string sort = null
                                , DateTime? startDateSince = default
                                , DateTime? startDateUntil = default
                                , int[] statusId = null
                                , DateTime? updatedSince = default
                                , DateTime? updatedUntil = default
                                , int[] versionId = null)
        {
            this.assigneeId     = assigneeId;
            this.attachment     = attachment;
            this.categoryId     = categoryId;
            this.count          = count;
            this.createdSince   = createdSince;
            this.createdUntil   = createdUntil;
            this.createdUserId  = createdUserId;
            this.dueDateSince   = dueDateSince;
            this.dueDateUntil   = dueDateUntil;
            this.id             = id;
            this.issueTypeId    = issueTypeId;
            this.keyword        = keyword;
            this.milestoneId    = milestoneId;
            this.offset         = offset;
            this.order          = order;
            this.parentChild    = parentChild;
            this.parentIssueId  = parentIssueId;
            this.priorityId     = priorityId;
            this.projectId      = projectId;
            this.resolutionId   = resolutionId;
            this.sharedFile     = sharedFile;
            this.sort           = sort;
            this.startDateSince = startDateSince;
            this.startDateUntil = startDateUntil;
            this.statusId       = statusId;
            this.updatedSince   = updatedSince;
            this.updatedUntil   = updatedUntil;
            this.versionId      = versionId;
        }

        QueryParameters IQueryParameter.AsParameter()
        {
            return new QueryParameters().Add(nameof(projectId), projectId)
                .Add(nameof(issueTypeId), issueTypeId)
                .Add(nameof(categoryId), categoryId)
                .Add(nameof(versionId), versionId)
                .Add(nameof(milestoneId), milestoneId)
                .Add(nameof(statusId), statusId)
                .Add(nameof(priorityId), priorityId)
                .Add(nameof(assigneeId), assigneeId)
                .Add(nameof(createdUserId), createdUserId)
                .Add(nameof(resolutionId), resolutionId)
                .Add(nameof(parentChild), EnumValueCache<ParentChildCondition>.GetValue(parentChild))
                .Add(nameof(attachment), attachment)
                .Add(nameof(sharedFile), sharedFile)
                .Add(nameof(sort), sort)
                .Add(nameof(order), EnumValueCache<OrderType>.GetString(order))
                .Add(nameof(offset), offset)
                .Add(nameof(count), count)
                .Add(nameof(createdSince), createdSince)
                .Add(nameof(createdUntil), createdUntil)
                .Add(nameof(updatedSince), updatedSince)
                .Add(nameof(updatedUntil), updatedUntil)
                .Add(nameof(startDateSince), startDateSince)
                .Add(nameof(startDateUntil), startDateUntil)
                .Add(nameof(dueDateSince), dueDateSince)
                .Add(nameof(dueDateUntil), dueDateUntil)
                .Add(nameof(id), id)
                .Add(nameof(parentIssueId), parentIssueId)
                .Add(nameof(keyword), keyword);
        }
        
        public static GetIssuesParameter None() => new GetIssuesParameter();
    }
}