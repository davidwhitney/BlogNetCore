using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class ContentItem
    {
        public ContentItemId Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public UserRef User { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public bool Published { get; set; }
        public List<AuditHistory> Audit { get; set; }
    }
}