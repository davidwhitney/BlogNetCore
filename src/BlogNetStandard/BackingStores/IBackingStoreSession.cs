using System.Collections.Generic;
using BlogNetStandard.DataModel;

namespace BlogNetStandard.BackingStores
{
    /// <summary>
    /// Per-Request lifecycle
    /// </summary>
    public interface IBackingStoreSession
    {
        IEnumerable<TType> Load<TType>(IEnumerable<Identity> contentItemIds) where TType : IPersistable;
        IEnumerable<TType> Load<TType>(params Identity[] contentItemIds) where TType : IPersistable;
        
        void Save<TType>(IEnumerable<TType> items) where TType : IPersistable;
        void Save<TType>(params TType[] items) where TType : IPersistable;

        IEnumerable<ContentItemMetadata> List(Identity bucketId, int batch = int.MaxValue, int limit = int.MaxValue);
    }
}