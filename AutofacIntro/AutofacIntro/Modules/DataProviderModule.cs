using AutofacIntro.Data;
using AutofacIntro.Data.Mysql;
using AutofacIntro.Data.Postgres;
using AutofacIntro.Data.Sqlite;
using Autofac;

namespace AutofacIntro
{
    public sealed class DataProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                 .RegisterType<MysqlDataProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();
            builder
                 .RegisterType<PostgresDataProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();
            builder
                 .RegisterType<SqliteDataProvider>()
                 .AsImplementedInterfaces()
                 .SingleInstance();
            builder
               .RegisterType<DataProviderFacade>()
               .AsImplementedInterfaces()
               .SingleInstance();
        }
    }
}
