using System;
using BlogNetStandard.BackingStores;

namespace BlogNetStandard
{
    public class ContentClient
    {
        public ContentConfiguration ContentConfiguration { get; }
        public IBackingStoreSession Session { get; }

        public ContentClient(ContentConfiguration contentConfiguration)
        {
            ContentConfiguration = contentConfiguration;
            Session = (IBackingStoreSession) Activator.CreateInstance(contentConfiguration.BackingStoreSessionType);
        }
    }
}