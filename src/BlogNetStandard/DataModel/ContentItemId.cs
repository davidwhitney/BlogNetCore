using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItemId
    {
        public string Value { get; set; } = Guid.NewGuid().ToString("N");
        public ContentBucketId ContentBucketId { get; set; } = new ContentBucketId();
    }
}