namespace BlogNetStandard.DataModel
{
    public abstract class AbstractIdentity
    {
        public static string DefaultId { get; } = "DEFAULT";
        public string Value { get; set; }

        protected AbstractIdentity()
            : this(DefaultId)
        {
        }

        protected AbstractIdentity(string id)
        {
            Value = id ?? DefaultId;
        }
    }

    public abstract class AbstractIdentity<TInheritingType> : AbstractIdentity where TInheritingType : AbstractIdentity<TInheritingType>, new()
    {
        public static TInheritingType Default { get; } = new TInheritingType {Value = DefaultId};
        
        protected AbstractIdentity(string id = null)
        {
            Value = id ?? DefaultId;
        }

        public static TInheritingType Of(string id) => new TInheritingType {Value = id};
        public static explicit operator AbstractIdentity<TInheritingType>(string stringId) => new TInheritingType{Value = stringId};
        public static explicit operator string(AbstractIdentity<TInheritingType> id) => id.Value;
    }
}