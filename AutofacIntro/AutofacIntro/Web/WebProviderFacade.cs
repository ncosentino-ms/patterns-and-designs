using System.Collections.Generic;

namespace AutofacIntro.Web
{
    public sealed class WebProviderFacade : IWebProviderFacade
    {
        public WebProviderFacade(IEnumerable<IWebProvider> providers)
        {

        }
    }
}
