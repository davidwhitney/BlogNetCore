using System;
using System.Collections.Generic;
using BlogNetStandard.DataModel;

namespace BlogNetStandard.BackingStores.FileSystemBackingStore
{
    public class FileSystemBackingStore : IBackingStoreSession
    {
        public IEnumerable<ContentItem> Load(IEnumerable<ContentItemId> contentItemIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContentItem> Load(params ContentItemId[] contentItemIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContentBucket> Load(IEnumerable<ContentBucketId> contentBucketIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContentBucket> Load(params ContentBucketId[] contentBucketId)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<ContentItem> items)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<ContentBucket> buckets)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContentItemWithUserRef> List(ContentBucketId bucketId, int batch = Int32.MaxValue, int limit = Int32.MaxValue)
        {
            throw new NotImplementedException();
        }
    }
}