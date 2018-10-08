using BlogNetStandard.BackingStores.InMemory;
using NUnit.Framework;

namespace BlogNetStandard.Test.Unit
{
    [TestFixture]
    public class ContentClientTests
    {
        private ContentClient _sut;
        private ContentConfiguration _contentServerConfiguration;

        [SetUp]
        public void SetUp()
        {
            _contentServerConfiguration = ContentConfiguration.MemoryStore();
            _sut = new ContentClient(_contentServerConfiguration);
        }

        [Test]
        public void Session_WhenConfigured_IsNotNull()
        {
            Assert.That(_sut.Session, Is.InstanceOf<InMemoryBackingStore>());
        }
    }
}
