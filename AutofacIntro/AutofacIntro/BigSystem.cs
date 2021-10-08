using AutofacIntro.Data;
using AutofacIntro.Web;

namespace AutofacIntro
{
    public sealed class BigSystem
    {
        private readonly IWebProviderFacade webProviderFacade;
        private readonly IDataProviderFacade dataProviderFacade;

        public BigSystem(
            IWebProviderFacade webProviderFacade,
            IDataProviderFacade dataProviderFacade)
        {
            this.webProviderFacade = webProviderFacade;
            this.dataProviderFacade = dataProviderFacade;
        }

        //public BigSystem()
        //{
        //    this.webProviderFacade = new WebProviderFacade();
        //    this.dataProviderFacade = new DataProviderFacade();
        //}

        public void GoDoStuff()
        {
        }
    }
}
