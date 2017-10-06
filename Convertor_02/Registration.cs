using System.Reflection;
using Autofac;
using log4net;

namespace Convertor_02
{
    internal class Registration
    {
        public static IContainer Autofac()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ProcessorService>().As<IWindowsService>();
            containerBuilder.Register(context => LogManager.GetLogger(Assembly.GetEntryAssembly(), "globallogger")).As<ILog>();

            return containerBuilder.Build();
        }
    }
}
