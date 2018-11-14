using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class User : IPersistable
    {
        public Identity Id { get; set; }
        public Identity GetStorageKey() => Id;

        public List<Role> Roles { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedUtc { get; set; }
        
        public List<ContentItemRef> Published { get; set; } = new List<ContentItemRef>();

        public static User Default { get; } = new User {CreatedUtc = DateTime.MinValue, Id = Identity.Of(Identity.DefaultId), DisplayName = "Admin", Name = "Admin"};

        public UserRef ToRef() => new UserRef {Id = Id, DisplayName = DisplayName, Name = Name};
    }
}