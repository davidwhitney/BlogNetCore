namespace BlogNetStandard.DataModel
{
    public interface IPersistable
    {
        AbstractIdentity GetStorageKey();
    }
}