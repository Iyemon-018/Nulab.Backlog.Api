namespace Nulab.Backlog.Api.Data.Parameters
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// GET: https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-list/#%E3%82%AF%E3%82%A8%E3%83%AA%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF%E3%83%BC
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

        public void SetProjectId(int[] projectId)
        {
            this.projectId = projectId;
        }

        public void SetIssueTypeId(int[] issueTypeId)
        {
            this.issueTypeId = issueTypeId;
        }

        public void SetCategoryId(int[] categoryId)
        {
            this.categoryId = categoryId;
        }

        public void SetVersionId(int[] versionId)
        {
            this.versionId = versionId;
        }

        public void SetMilestoneId(int[] milestoneId)
        {
            this.milestoneId = milestoneId;
        }

        public void SetStatusId(int[] statusId)
        {
            this.statusId = statusId;
        }

        public void SetPriorityId(int[] priorityId)
        {
            this.priorityId = priorityId;
        }

        public void SetAssigneeId(int[] assigneeId)
        {
            this.assigneeId = assigneeId;
        }

        public void SetCreatedUserId(int[] createdUserId)
        {
            this.createdUserId = createdUserId;
        }

        public void SetResolutionId(int[] resolutionId)
        {
            this.resolutionId = resolutionId;
        }

        public void SetParentChild(ParentChildCondition parentChild)
        {
            this.parentChild = parentChild;
        }

        public void SetAttachement(bool attachement)
        {
            attachment = attachement;
        }

        public void SetSharedFile(bool sharedFile)
        {
            this.sharedFile = sharedFile;
        }

        public void SetSort(string sort)
        {
            this.sort = sort;
        }

        public void SetOrder(OrderType order)
        {
            this.order = order;
        }

        public void SetOffset(int offset)
        {
            this.offset = offset;
        }

        public void SetCount(int count)
        {
            this.count = count;
        }

        public void SetCreatedSince(DateTime createdSince)
        {
            this.createdSince = createdSince;
        }

        public void SetCreatedUntil(DateTime createdUntil)
        {
            this.createdUntil = createdUntil;
        }

        public void SetUpdatedSince(DateTime updatedSince)
        {
            this.updatedSince = updatedSince;
        }

        public void SetUpdatedUntil(DateTime updatedUntil)
        {
            this.updatedUntil = updatedUntil;
        }

        public void SetStartDateSince(DateTime startDateSince)
        {
            this.startDateSince = startDateSince;
        }

        public void SetStartDateUntil(DateTime startDateUntil)
        {
            this.startDateUntil = startDateUntil;
        }

        public void SetDueDateSince(DateTime dueDateSince)
        {
            this.dueDateSince = dueDateSince;
        }

        public void SetDueDateUntil(DateTime dueDateUntil)
        {
            this.dueDateUntil = dueDateUntil;
        }

        public void SetId(int[] id)
        {
            this.id = id;
        }

        public void SetParentIssueId(int[] parentIssueId)
        {
            this.parentIssueId = parentIssueId;
        }

        public void SetKeyword(string keyword)
        {
            this.keyword = keyword;
        }

        public static GetIssuesParameter None() => new GetIssuesParameter();
    }
}