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

        [SetUp]
        public void SetUp()
        {
            _memoryStore = new InMemoryBackingStore();
            _bucket = ContentBucket.Default("My Bucket");

            _memoryStore.Save(User.Default);
            _memoryStore.Save(_bucket);

            _item = new ContentItem(User.Default.ToRef())
            {
                Metadata = {Title = "Some post"},
                Body = "Some content"
            };
        }

        [Test]
        public void Load_BucketExists_ReturnsSomething()
        {
            var bucket = _memoryStore.Load<ContentBucket>(Identity.Default()).Single();

            Assert.That(bucket, Is.Not.Null);
            Assert.That(bucket.Name, Is.EqualTo("My Bucket"));
        }

        [Test]
        public void Load_UserExists_NameIsCorrect()
        {
            var user = _memoryStore.Load<User>(Identity.Default()).Single();

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Name, Is.EqualTo("Admin"));
        }

        [Test]
        public void Load_CanSaveAndLoadItemsFromBucket()
        {
            _memoryStore.Save(_item);

            var itemRetrieved = _memoryStore.Load<ContentItem>(_item.Id).Single();

            Assert.That(itemRetrieved.Metadata.Title, Is.EqualTo("Some post"));
        }

        [Test]
        public void Save_ItemAppearsInContentBucket()
        {
            _memoryStore.Save(_item);

            var defaultBucket = _memoryStore.Load<ContentBucket>(Identity.Default()).Single();

            Assert.That(defaultBucket.Items.Any(i => i.Key.Value == _item.Id.Value));
        }

        [Test]
        public void Load_ReturnsACopyNotTheSameInstances()
        {
            _memoryStore.Save(_item);

            var itemRetrieved = _memoryStore.Load<ContentItem>(_item.Id);

            Assert.That(itemRetrieved.Single(), Is.Not.EqualTo(_item));
        }
    }
}