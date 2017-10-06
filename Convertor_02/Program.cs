using System;
using System.IO;
using System.Reflection;
using Autofac;
using log4net;
using log4net.Config;

namespace Convertor_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var container = Registration.Autofac();

            try
            {
                var service = container.Resolve<IWindowsService>();
                service.Start();
            }
            catch (Exception ex)
            {
                var log = container.Resolve<ILog>();
                log.Fatal($"Unhandled exception occurred. {ex.Message}");
            }
        }
    }
}
