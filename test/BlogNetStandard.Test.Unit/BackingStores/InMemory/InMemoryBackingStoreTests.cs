using System.Linq;
using BlogNetStandard.BackingStores.InMemory;
using BlogNetStandard.DataModel;
using NUnit.Framework;

namespace BlogNetStandard.Test.Unit.BackingStores.InMemory
{
    [TestFixture]
    public class InMemoryBackingStoreTests
    {
        private InMemoryBackingStore _memoryStore;
        private ContentBucket _bucket;
        private ContentItem _item;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _memoryStore = new InMemoryBackingStore();
            _bucket = new ContentBucket {Name = "My Bucket"};
            _user = User.Default;

            _memoryStore.Save(_user);
            _memoryStore.Save(_bucket);

            _item = new ContentItem(ContentBucketId.Default)
            {
                Metadata = new ContentItemMetadata {Title = "Some post"},
                Body = "Some content",
            };
        }

        [Test]
        public void Load_BucketExists_ReturnsSomething()
        {
            var bucket = _memoryStore.Load(ContentBucketId.Default).Single();

            Assert.That(bucket, Is.Not.Null);
        }

        [Test]
        public void Load_BucketExists_NameIsCorrect()
        {
            var bucket = _memoryStore.Load(ContentBucketId.Default).Single();

            Assert.That(bucket.Name, Is.EqualTo("My Bucket"));
        }

        [Test]
        public void Load_CanSaveAndLoadItemsFromBucket()
        {
            _memoryStore.Save(_item);

            var itemRetrieved = _memoryStore.Load(_item.Id).Single();

            Assert.That(itemRetrieved.Metadata.Title, Is.EqualTo("Some post"));
        }

        [Test]
        public void Save_ItemAppearsInContentBucket()
        {
            _memoryStore.Save(_item);

            var defaultBucket = _memoryStore.Load(ContentBucketId.Default).Single();

            Assert.That(defaultBucket.Items.Any(i => i.Key == _item.Id.Value));
        }

        [Test]
        public void Load_ReturnsACopyNotTheSameInstances()
        {
            _memoryStore.Save(_item);

            var itemRetrieved = _memoryStore.Load(_item.Id);

            Assert.That(itemRetrieved.Single(), Is.Not.EqualTo(_item));
        }
    }
}