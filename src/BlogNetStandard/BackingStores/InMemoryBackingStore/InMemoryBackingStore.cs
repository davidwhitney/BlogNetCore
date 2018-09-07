using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogNetStandard.DataModel;
using Newtonsoft.Json;

namespace BlogNetStandard.BackingStores.InMemoryBackingStore
{
    public class InMemoryBackingStore : IBackingStoreSession
    {
        private readonly Dictionary<string, string> _items = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _buckets = new Dictionary<string, string>();

        public ContentBucket Add(ContentBucket bucket)
        {
            var raw = JsonConvert.SerializeObject(bucket);
            _buckets.Add(bucket.Id.Id, raw);
            return bucket;
        }

        public ContentItem Add(ContentItem item)
        {
            var raw = JsonConvert.SerializeObject(item);
            _items.Add($"{item.Id.ContentBucketId}_{item.Id.Id}", raw);
            return item;
        }

        public IEnumerable<ContentItem> Load(IEnumerable<ContentItemId> contentItemIds)
        {
            return contentItemIds.Select(x => $"{x.ContentBucketId}_{x.Id}")
                .Where(key => _items.ContainsKey(key))
                .Select(key => _items[key])
                .Select(JsonConvert.DeserializeObject<ContentItem>);
        }

        public IEnumerable<ContentItem> Load(params ContentItemId[] contentItemIds)
            => Load(contentItemIds.ToList());

        public IEnumerable<ContentBucket> Load(IEnumerable<ContentBucketId> contentBucketIds)
        {
            return contentBucketIds
                .Where(key => _buckets.ContainsKey(key.Id))
                .Select(key => _buckets[key.Id])
                .Select(JsonConvert.DeserializeObject<ContentBucket>);
        }

        public IEnumerable<ContentBucket> Load(params ContentBucketId[] contentBucketIds)
            => Load(contentBucketIds.ToList());

        public void Save(IEnumerable<ContentItem> items)
        {
            foreach (var item in items)
            {
                _items[$"{item.Id.ContentBucketId}_{item.Id.Id}"] = JsonConvert.SerializeObject(item);
            }
        }

        public void Save(IEnumerable<ContentBucket> buckets)
        {
            foreach (var item in buckets)
            {
                _buckets[item.Id.Id] = JsonConvert.SerializeObject(item);
            }
        }

        public IEnumerable<ContentItemWithUserRef> List(ContentBucketId bucketId, int batch = Int32.MaxValue, int limit = Int32.MaxValue)
        {
            return _items.Values
                .Select(JsonConvert.DeserializeObject<ContentItem>)
                .Where(x => x.Id.ContentBucketId.Id == bucketId.Id)
                .Select(ci =>new ContentItemWithUserRef
                {
                    Id = ci.Id,
                    PublishDateUtc = ci.PublishDateUtc,
                    Title = ci.Title,
                    User = ci.User
                });
        }
    }
}
