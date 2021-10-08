using Autofac;

namespace AutofacIntro
{
    public sealed class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterType<BigSystem>()
                .SingleInstance();
        }
    }
}
