using System;

namespace Nulab.Backlog.Api
{
    public class UserActivity
    {
        public int id { get; set; }
        public Project project { get; set; }
        public int type { get; set; }
        public Content content { get; set; }
        public Notification[] notifications { get; set; }
        public Createduser createdUser { get; set; }
        public DateTime created { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string projectKey { get; set; }
        public string name { get; set; }
        public bool chartEnabled { get; set; }
        public bool subtaskingEnabled { get; set; }
        public bool projectLeaderCanEditProjectLeader { get; set; }
        public object textFormattingRule { get; set; }
        public bool archived { get; set; }
        public int displayOrder { get; set; }
    }

    public class Content
    {
        public int id { get; set; }
        public int key_id { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public Comment comment { get; set; }
        public Change[] changes { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public string content { get; set; }
    }

    public class Change
    {
        public string field { get; set; }
        public string new_value { get; set; }
        public string old_value { get; set; }
        public string type { get; set; }
    }

    public class Createduser
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public string lang { get; set; }
        public string mailAddress { get; set; }
    }

    public class Notification
    {
        public int id { get; set; }
        public bool alreadyRead { get; set; }
        public int reason { get; set; }
        public User user { get; set; }
        public bool resourceAlreadyRead { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public int roleType { get; set; }
        public string lang { get; set; }
        public string mailAddress { get; set; }
    }
}
