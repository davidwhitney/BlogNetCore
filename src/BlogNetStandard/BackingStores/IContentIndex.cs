using System.Collections.Generic;
using BlogNetStandard.DataModel;

namespace BlogNetStandard.BackingStores
{
    public interface IContentIndex
    {
        IEnumerable<ContentItemMetadata> Search(string query, int batch = int.MaxValue, int limit = int.MaxValue);
    }
}