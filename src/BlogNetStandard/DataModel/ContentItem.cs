using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItem : IPersistable
    {
        public AbstractIdentity GetStorageKey() => Id;
        public ContentItemId Id { get; set; }

        public string Body { get; set; }

        public ContentItemMetadata Metadata { get; set; }

        public ContentItem(ContentBucketId bucketId = null)
        {
            Id = new ContentItemId
            {
                Value = Guid.NewGuid().ToString("N"),
                ContentBucketId = bucketId ?? new ContentBucketId()
            };

            Metadata = new ContentItemMetadata();
        }
    }
}