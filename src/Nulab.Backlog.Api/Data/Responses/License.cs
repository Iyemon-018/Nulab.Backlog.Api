namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class License
    {
        public bool active { get; set; }
        public int attachmentLimit { get; set; }
        public int attachmentLimitPerFile { get; set; }
        public int attachmentNumLimit { get; set; }
        public bool attribute { get; set; }
        public int attributeLimit { get; set; }
        public bool burndown { get; set; }
        public int commentLimit { get; set; }
        public int componentLimit { get; set; }
        public bool fileSharing { get; set; }
        public bool gantt { get; set; }
        public bool git { get; set; }
        public int issueLimit { get; set; }
        public int licenceTypeId { get; set; }
        public DateTime limitDate { get; set; }
        public bool nulabAccount { get; set; }
        public bool parentChildIssue { get; set; }
        public bool postIssueByMail { get; set; }
        public int projectLimit { get; set; }
        public int pullRequestAttachmentLimitPerFile { get; set; }
        public int pullRequestAttachmentNumLimit { get; set; }
        public bool remoteAddress { get; set; }
        public int remoteAddressLimit { get; set; }
        public DateTime startedOn { get; set; }
        public long storageLimit { get; set; }
        public bool subversion { get; set; }
        public bool subversionExternal { get; set; }
        public int userLimit { get; set; }
        public int versionLimit { get; set; }
        public bool wikiAttachment { get; set; }
        public int wikiAttachmentLimitPerFile { get; set; }
        public int wikiAttachmentNumLimit { get; set; }
    }
}