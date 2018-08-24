using NUnit.Framework;
using System;
using BlogNetStandard.BackingStores.FileSystemBackingStore;

namespace BlogNetStandard.Test.Unit
{
    [TestFixture]
    public class ContentClientTests
    {
        [Test]
        public void True()
        {
            var contentServerConfiguration = ContentConfiguration.LocalStore<FileSystemBackingStore>();

            var sut = new ContentClient(contentServerConfiguration);
            
            //sut.Session
        }
    }
}
