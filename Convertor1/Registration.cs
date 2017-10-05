using Autofac;
using log4net;

namespace Convertor1
{
    internal class Registration
    {
        public static IContainer Autofac()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ProcessorService>().As<IWindowsService>();
            containerBuilder.Register(context => LogManager.GetLogger("Convertor1")).As<ILog>();

            return containerBuilder.Build();
        }
    }
}
