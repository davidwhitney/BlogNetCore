using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlogNetStandard.DataModel;
using Newtonsoft.Json;

namespace BlogNetStandard.BackingStores.InMemory
{
    public class InMemoryBackingStore : IBackingStoreSession
    {
        private readonly Dictionary<Type, Dictionary<string, string>> _storage =
            new Dictionary<Type, Dictionary<string, string>>
            {
                {typeof(User), new Dictionary<string, string>()},
                {typeof(ContentItem), new Dictionary<string, string>()},
                {typeof(ContentBucket), new Dictionary<string, string>()},
            };

        public IEnumerable<TType> Load<TType>(IEnumerable<Identity> contentItemIds) where TType : IPersistable
        {
            return _storage[typeof(TType)]
                .Where(keyValuePair => _storage[typeof(TType)].ContainsKey(keyValuePair.Key))
                .Select(keyValuePair => _storage[typeof(TType)][keyValuePair.Key])
                .Select(JsonConvert.DeserializeObject<TType>)
                .ToList();
        }

        public IEnumerable<TType> Load<TType>(params Identity[] contentItemIds) where TType : IPersistable
        {
            return Load<TType>(contentItemIds.ToList());
        }

        public void Save<TType>(IEnumerable<TType> items) where TType : IPersistable
        {
            foreach (var item in items)
            {
                _storage[typeof(TType)][item.Id.Value] = JsonConvert.SerializeObject(item);

                var interceptor = GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(m => m.Name == nameof(OnSave))
                    .SingleOrDefault(m => m.GetParameters().SingleOrDefault()?.ParameterType == typeof(TType));

                interceptor?.Invoke(this, new object[] {item});
            }
        }

        public void Save<TType>(params TType[] items) where TType : IPersistable
        {
            Save<TType>(items.ToList());
        }

        public IEnumerable<ContentItemMetadata> List(Identity bucketId, int batch = int.MaxValue, int limit = int.MaxValue)
        {
            return _storage[typeof(ContentItem)].Values
                .Select(JsonConvert.DeserializeObject<ContentItem>)
                .Where(x => x.ContentBucketId.Value == bucketId.Value)
                .Select(ci => ci.Metadata);
        }

        private void OnSave(ContentItem item)
        {
            var bucket = Load<ContentBucket>(item.ContentBucketId).Single();
            bucket.Items.Add(item.Id, item.Metadata);
            Save(bucket);

            var user = Load<User>(item.Metadata.Author.Id).Single();
            user.Published.Add(item.ToRef());
            Save(user);
        }

        private void OnSave(ContentBucket bucket)
        {

        }

        private void OnSave(User item)
        {

        }
    }
}
