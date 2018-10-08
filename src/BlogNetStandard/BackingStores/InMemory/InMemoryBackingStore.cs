using System;
using System.Collections.Generic;
using System.Linq;
using BlogNetStandard.DataModel;
using Newtonsoft.Json;

namespace BlogNetStandard.BackingStores.InMemory
{
    public class InMemoryBackingStore : IBackingStoreSession
    {
        private readonly Dictionary<string, string> _items = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _buckets = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();

        public IEnumerable<ContentItem> Load(IEnumerable<ContentItemId> contentItemIds)
        {
            return contentItemIds.Select(x => $"{x.ContentBucketId}_{x.Value}")
                .Where(key => _items.ContainsKey(key))
                .Select(key => _items[key])
                .Select(JsonConvert.DeserializeObject<ContentItem>);
        }

        public IEnumerable<ContentItem> Load(params ContentItemId[] contentItemIds)
            => Load(contentItemIds.ToList());

        public IEnumerable<ContentBucket> Load(IEnumerable<ContentBucketId> contentBucketIds)
        {
            return contentBucketIds
                .Where(key => _buckets.ContainsKey(key.Value))
                .Select(key => _buckets[key.Value])
                .Select(JsonConvert.DeserializeObject<ContentBucket>);
        }

        public IEnumerable<ContentBucket> Load(params ContentBucketId[] contentBucketIds)
            => Load(contentBucketIds.ToList());

        public void Save(params ContentItem[] items) => Save((IEnumerable<ContentItem>)items);
        public void Save(IEnumerable<ContentItem> items)
        {
            foreach (var item in items)
            {
                _items[$"{item.Id.ContentBucketId}_{item.Id.Value}"] = JsonConvert.SerializeObject(item);

                var bucket = Load(item.Id.ContentBucketId).Single();
                bucket.Items.Add(item.Id.Value, item.Metadata);

                Save(new[] {bucket});

            }
        }

        public void Save(params ContentBucket[] buckets) => Save((IEnumerable<ContentBucket>)buckets);
        public void Save(IEnumerable<ContentBucket> buckets)
        {
            foreach (var item in buckets)
            {
                _buckets[item.Id.Value] = JsonConvert.SerializeObject(item);
            }
        }

        public void Save(params User[] users) => Save((IEnumerable<User>)users);
        public void Save(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                _users[item.Id.Value] = JsonConvert.SerializeObject(item);
            }
        }

        public IEnumerable<ContentItemMetadata> List(ContentBucketId bucketId, int batch = Int32.MaxValue, int limit = Int32.MaxValue)
        {
            return _items.Values
                .Select(JsonConvert.DeserializeObject<ContentItem>)
                .Where(x => x.Id.ContentBucketId.Value == bucketId.Value)
                .Select(ci => ci.Metadata);
        }
    }
}
