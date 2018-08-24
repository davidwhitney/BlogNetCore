using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class ContentBucket
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUtc { get; set; }
        public List<ContentItemWithUserRef> ContentItems { get; set; }
    }
}