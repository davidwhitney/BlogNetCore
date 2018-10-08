using System;

namespace BlogNetStandard.DataModel
{
    public class ContentBucket
    {
        public ContentBucketId Id { get; set; }
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }

        public ContentBucket(ContentBucketId id = null)
        {
            Id = id ?? new ContentBucketId();
        }
    }
}