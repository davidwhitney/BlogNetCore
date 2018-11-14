using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class ContentItemMetadata
    {
        public string Slug { get; set; }
        public string Title { get; set; }

        public UserRef Author { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public bool Published { get; set; } = true;
        public List<AuditHistory> Audit { get; set; } = new List<AuditHistory>();

        public ContentItemMetadata(UserRef author)
        {
            Author = author;
        }
    }
}