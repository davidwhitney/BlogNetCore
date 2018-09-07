using System;
using BlogNetStandard.BackingStores;
using BlogNetStandard.BackingStores.FileSystemBackingStore;
using BlogNetStandard.BackingStores.InMemoryBackingStore;

namespace BlogNetStandard
{
    public class ContentConfiguration
    {
        public Type BackingStoreSessionType { get; set; }
        public Type BackingStoreSearchProvider { get; set; }
        public string RemoteContentStoreRoot { get; set; }

        public static ContentConfiguration LocalFileStore()
        {
            return new ContentConfiguration
            {
                BackingStoreSessionType = typeof(FileSystemBackingStore),
                BackingStoreSearchProvider = typeof(NullSearchProvider)
            };
        }

        public static ContentConfiguration MemoryStore()
        {
            return new ContentConfiguration
            {
                BackingStoreSessionType = typeof(InMemoryBackingStore),
                BackingStoreSearchProvider = typeof(NullSearchProvider)
            };
        }
    }
}
