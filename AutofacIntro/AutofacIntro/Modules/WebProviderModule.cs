using AutofacIntro.Web;
using AutofacIntro.Web.Bing;
using AutofacIntro.Web.Yahoo;
using System.Net;
using Autofac;

namespace AutofacIntro
{
    public sealed class WebProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                 .Register(x =>
                 {
                     var webClient = new WebClient();
                     var webClientWrapper = new WebClientWrapper(webClient);
                     return webClientWrapper;
                 })
                 .AsImplementedInterfaces();
                 //.SingleInstance(); // we need unique instances of these!

            builder
                 .RegisterType<YahooWebProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();
            builder
                 .RegisterType<BingWebProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();
            builder
                 .RegisterType<BingWebProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();


            builder
                .RegisterType<WebProviderFacade>()
                .As<IWebProviderFacade>()
                .SingleInstance();
        }
    }
}
