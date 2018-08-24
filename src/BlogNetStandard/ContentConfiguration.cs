using System;
using BlogNetStandard.BackingStores;

namespace BlogNetStandard
{
    public class ContentConfiguration
    {
        public Type BackingStoreSessionType { get; set; }
        public string RemoteContentStoreRoot { get; set; }

        public static ContentConfiguration LocalStore<T>() where T: IBackingStoreSession
        {
            return new ContentConfiguration
            {
                BackingStoreSessionType = typeof(T)
            };
        }
    }
}
