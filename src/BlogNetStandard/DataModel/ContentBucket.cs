using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class ContentBucket : IPersistable
    {
        public AbstractIdentity GetStorageKey() => Id;
        public ContentBucketId Id { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }

        public Dictionary<string, ContentItemMetadata> Items { get; set; } = new Dictionary<string, ContentItemMetadata>();

        public ContentBucket(ContentBucketId id = null)
        {
            Id = id ?? new ContentBucketId();
        }
    }
}