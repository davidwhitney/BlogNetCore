using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNetStandard.BackingStores
{
    public class NullSearchProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
