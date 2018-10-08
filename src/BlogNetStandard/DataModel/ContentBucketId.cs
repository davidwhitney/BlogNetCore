using System;

namespace BlogNetStandard.DataModel
{
    public class ContentBucketId
    {
        public static string DefaultContentBucketId { get; } = "DEFAULT";
        public static ContentBucketId Default { get; } = new ContentBucketId(DefaultContentBucketId);

        public string Value { get; set; }

        public ContentBucketId(string id = null)
        {
            Value = id ?? DefaultContentBucketId;
        }

        public static ContentBucketId Of(string id) => new ContentBucketId(id);
        public static explicit operator ContentBucketId(string stringId) => new ContentBucketId(stringId);
        public static explicit operator string(ContentBucketId id) => id.Value;
    }
}