using System;

namespace BlogNetStandard.DataModel
{
    public class AuditHistory
    {
        public string Action { get; set; }
        public UserRef User { get; set; }
        public DateTime TimestampUtc { get; set; }
    }
}