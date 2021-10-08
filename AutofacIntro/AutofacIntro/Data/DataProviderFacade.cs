using System.Collections.Generic;

namespace AutofacIntro.Data
{
    public sealed class DataProviderFacade : IDataProviderFacade
    {
        public DataProviderFacade(IEnumerable<IDataProvider> providers)
        {

        }
    }
}
