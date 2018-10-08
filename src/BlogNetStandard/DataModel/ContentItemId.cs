using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItemId : AbstractIdentity<ContentItemId>
    {
        public ContentBucketId ContentBucketId { get; set; } = new ContentBucketId();
    }
}