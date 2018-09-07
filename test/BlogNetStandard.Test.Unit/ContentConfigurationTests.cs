using BlogNetStandard.BackingStores;
using BlogNetStandard.BackingStores.FileSystemBackingStore;
using NUnit.Framework;

namespace BlogNetStandard.Test.Unit
{
    [TestFixture]
    public class ContentConfigurationTests
    {
        [Test]
        public void ForLocal_GeneratesLocalConfigStore()
        {
            var config = ContentConfiguration.LocalFileStore();
            
            Assert.That(config.BackingStoreSessionType, Is.EqualTo(typeof(FileSystemBackingStore)));
        }
    }
}