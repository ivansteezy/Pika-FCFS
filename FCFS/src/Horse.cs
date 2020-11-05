using System;
using System.Threading;

namespace FCFS.src
{
    class Horse : Competitor
    {
        public uint priority  { get; set; }
        public Thread process { get; set; }
        public string name    { get; set; }
        public uint speed     { get; set; }

        public Horse(uint priority, Thread process, string name, uint speed)
        {
            this.priority = priority;
            this.process = process;
            this.name = name;
            this.speed = speed;
        }

        public static void Run(object horse)
        {
            var h = (Horse)horse;
            Console.WriteLine("{0} Ha comenzado a correr", h.name);
            for (var i = 0; i < 10; i++)
            {
                // About to run
                Thread.Sleep((int)h.speed);
            }
            Console.WriteLine("{0} ha terminado la carrera!", h.name);
        }
    }
}
