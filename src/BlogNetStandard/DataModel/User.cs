using System;
using System.Collections.Generic;

namespace BlogNetStandard.DataModel
{
    public class User
    {
        public string Id { get; set; }
        public List<Role> Roles { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedUtc { get; set; }
        
        public List<ContentItemRef> Published { get; set; }
    }
}