using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItem : IPersistable
    {
        public Identity Id { get; set; }
        public Identity ContentBucketId { get; set; }

        public string Body { get; set; }

        public ContentItemMetadata Metadata { get; set; }

        public ContentItem(UserRef author, Identity bucketId = null)
        {
            Id = new Identity();
            ContentBucketId = bucketId ?? Identity.Default();
            Metadata = new ContentItemMetadata(author);
        }

        public ContentItemRef ToRef() => new ContentItemRef {Id = Id, PublishDateUtc = Metadata.PublishDateUtc, Title = Metadata.Title};
    }
}