using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItemRef
    {
        public string Id { get; set; }
        public string ContentBucketId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDateUtc { get; set; }
    }
}