using System;

namespace BlogNetStandard.DataModel
{
    public class ContentBucket
    {
        public ContentBucketId Id { get; set; } = new ContentBucketId();
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
    }
}