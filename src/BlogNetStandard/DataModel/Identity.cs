using System;

namespace BlogNetStandard.DataModel
{
    public class Identity
    {
        public static string DefaultId { get; } = "DEFAULT";
        public string Value { get; set; }

        public Identity()
            : this(Guid.NewGuid().ToString("N"))
        {
        }

        public Identity(string id)
        {
            Value = id ?? DefaultId;
        }

        public static Identity Of(string id) => new Identity { Value = id};
        public static explicit operator Identity(string stringId) => new Identity { Value = stringId};
        public static explicit operator string(Identity id) => id.Value;

        public static Identity Default() => new Identity(DefaultId);
        public override string ToString() => Value;
    }
}