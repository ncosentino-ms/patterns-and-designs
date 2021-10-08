using Autofac;
using System.Reflection;

namespace AutofacIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            // register stuff
            containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = containerBuilder.Build();
            var bigSystem = container.Resolve<BigSystem>();
            bigSystem.GoDoStuff();
        }
    }
}
