using System;

namespace BlogNetStandard.DataModel
{
    public class ContentBucketId
    {
        public string Id { get; set; }

        public ContentBucketId(string id = null)
        {
            Id = id ?? Guid.NewGuid().ToString();
        }

        public static ContentBucketId Of(string id) => new ContentBucketId(id);
    }
}