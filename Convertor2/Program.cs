using Autofac;
using log4net;
using log4net.Config;
using Topshelf;
using Topshelf.Autofac;

namespace Convertor2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            var container = Registration.Autofac();

            HostFactory.Run(x =>
            {
                x.UseAutofacContainer(container);
                x.UseLog4Net();
                x.Service<IWindowsService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
                x.OnException(ex =>
                {
                    var log = container.Resolve<ILog>();
                    log.Fatal($"Unhandled exception occurred. {ex.Message}");
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetDescription("The convertor 2.");
            });
        }
    }
}
