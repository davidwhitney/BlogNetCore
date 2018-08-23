using System;
using System.Collections.Generic;

namespace BlogNetStandard
{
    public class ContentConfiguration
    {
    }

    public class Post
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public AuthorRef Author { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public bool Published { get; set; }
        public List<AuditHistory> Audit { get; set; }
    }

    public class AuditHistory
    {
    }

    public class AuthorRef
    {
    }

    public class Author
    {
        public List<Role> Roles { get; set; }
    }

    public enum Role
    {
    }

    public class ContentBucket
    {
        public string Name { get; set; }
    }
}
