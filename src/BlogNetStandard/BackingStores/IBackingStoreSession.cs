using System.Collections.Generic;
using System.Xml.Linq;
using BlogNetStandard.DataModel;

namespace BlogNetStandard.BackingStores
{
    /// <summary>
    /// Per-Request lifecycle
    /// </summary>
    public interface IBackingStoreSession
    {
        IEnumerable<ContentItem> Load(IEnumerable<ContentItemId> contentItemIds);
        IEnumerable<ContentItem> Load(params ContentItemId[] contentItemIds);

        IEnumerable<ContentBucket> Load(IEnumerable<ContentBucketId> contentBucketIds);
        IEnumerable<ContentBucket> Load(params ContentBucketId[] contentBucketIds);

        void Save(IEnumerable<ContentItem> items);
        void Save(IEnumerable<ContentBucket> buckets);

        IEnumerable<ContentItemMetadata> List(ContentBucketId bucketId, int batch = int.MaxValue, int limit = int.MaxValue);
    }
}