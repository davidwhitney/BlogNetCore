using System;

namespace BlogNetStandard.DataModel
{
    public class ContentItemRef
    {
        public ContentItemId Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDateUtc { get; set; }
    }
}