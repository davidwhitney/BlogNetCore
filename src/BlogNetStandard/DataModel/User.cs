using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class User : IPersistable
    {
        public AbstractIdentity GetStorageKey() => Id;
        public UserId Id { get; set; }

        public List<Role> Roles { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedUtc { get; set; }
        
        public List<ContentItemRef> Published { get; set; } = new List<ContentItemRef>();

        public static User Default { get; } = new User {CreatedUtc = DateTime.MinValue, Id = UserId.Default, DisplayName = "", Name = ""};
    }
}