using NUnit.Framework;
using System;
using System.Linq;
using BlogNetStandard.BackingStores.InMemoryBackingStore;
using BlogNetStandard.DataModel;

namespace BlogNetStandard.Test.Unit
{
    [TestFixture]
    public class ContentClientTests
    {
        private ContentClient _sut;
        private ContentConfiguration _contentServerConfiguration;
        private InMemoryBackingStore _memoryStore;
        private ContentBucket _bucket;

        [SetUp]
        public void SetUp()
        {
            _contentServerConfiguration = ContentConfiguration.MemoryStore();
            _sut = new ContentClient(_contentServerConfiguration);
            _memoryStore = (InMemoryBackingStore)_sut.Session;

            _bucket = new ContentBucket {Name = "My Bucket", Id = ContentBucketId.Of("1")};

            _memoryStore.Add(_bucket);
        }

        [Test]
        public void Load_BucketExists_ReturnsSomething()
        {
            var bucket = _sut.Session.Load(ContentBucketId.Of("1")).Single();

            Assert.That(bucket, Is.Not.Null);
        }
    }
}
