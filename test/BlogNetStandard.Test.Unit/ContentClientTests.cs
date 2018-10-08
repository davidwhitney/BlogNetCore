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

            _bucket = new ContentBucket {Name = "My Bucket"};

            _memoryStore.Add(_bucket);
        }

        [Test]
        public void Load_BucketExists_ReturnsSomething()
        {
            var bucket = _sut.Session.Load(ContentBucketId.Default).Single();

            Assert.That(bucket, Is.Not.Null);
        }

        [Test]
        public void Load_BucketExists_NameIsCorrect()
        {
            var bucket = _sut.Session.Load(ContentBucketId.Default).Single();

            Assert.That(bucket.Name, Is.EqualTo("My Bucket"));
        }

        [Test]
        public void Load_CanSaveAndLoadItemsFromBucket()
        {
            var item = new ContentItem(ContentBucketId.Default)
            {
                Title = "Some post",
                Body = "Some content",
            };

            _sut.Session.Save(new[] {item});

            var itemRetrieved = _sut.Session.Load(item.Id);

            Assert.That(itemRetrieved.Single().Title, Is.EqualTo("Some post"));
        }

        [Test]
        public void Load_ReturnsACopyNotTheSameInstances()
        {
            var item = new ContentItem(ContentBucketId.Default)
            {
                Title = "Some post",
                Body = "Some content",
            };

            _sut.Session.Save(new[] {item});

            var itemRetrieved = _sut.Session.Load(item.Id);

            Assert.That(itemRetrieved.Single(), Is.Not.EqualTo(item));
        }
    }
}
