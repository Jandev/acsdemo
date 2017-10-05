using System;
using System.Threading;
using log4net;

namespace Convertor1
{
    internal class ProcessorService : IWindowsService
    {
        private readonly ILog log;
        private long counter = 0;

        public ProcessorService(ILog log)
        {
            this.log = log;
        }

        public bool Start()
        {
            Run();
            var thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
            this.log.Info("Started");
            return true;
        }

        private void Run()
        {
            while (true)
            {
                counter++;
                Thread.Sleep(5000);
                if (counter % 10 == 0)
                {
                    log.Fatal($"Serious error for counter {counter}");
                    throw new Exception("Very serious error!");
                }
                this.log.Info($"Everything is ok for count {counter}");
            }
        }

        public bool Stop()
        {
            this.log.Info("Stopped");
            return true;
        }
    }

    internal interface IWindowsService
    {
        bool Start();
        bool Stop();
    }
}
