using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Concurrent;

namespace FCFS
{
    public partial class App : Application
    {
        static class Globals
        {
            static public ConcurrentBag<Task> runningTasks { get; } = new ConcurrentBag<Task>();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            while(Globals.runningTasks.Any(t => !t.IsCompleted))
            {
                await Task.Yield();
            }
            Environment.Exit(0);
        }
    }
}
