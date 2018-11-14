using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class ContentBucket : IPersistable
    {
        public Identity Id { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }

        public Dictionary<Identity, ContentItemMetadata> Items { get; set; } = new Dictionary<Identity, ContentItemMetadata>();

        public ContentBucket(Identity id = null)
        {
            Id = id ?? new Identity();
        }

        public static ContentBucket Default(string name = null) => new ContentBucket(Identity.Default())
        {
            Name = name
        };
    }
}