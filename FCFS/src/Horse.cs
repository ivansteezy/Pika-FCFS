using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FCFS.src
{
    class Horse : Competitor
    {
        public uint priority  { get; set; }
        public Thread process { get; set; }
        public string name    { get; set; }
        public uint speed     { get; set; }
        public Image sprite   { get; set; }

        public delegate void UpdateSpritePosition(double pos);

        public Horse(uint priority, Thread process, string name, uint speed, Image sprite)
        {
            this.priority = priority;
            this.process = process;
            this.name = name;
            this.speed = speed;
            this.sprite = sprite;
        }

        private void UpdatePos(double pos)
        {
            Canvas.SetLeft(this.sprite, pos);
        }

        public static void Run(object horse)
        {
            var h = (Horse)horse;
            //Console.WriteLine("{0} Ha comenzado a correr", h.name);
            //for (var i = 0; i < 10; i++)
            //{
            //    // About to run
            //    Thread.Sleep((int)h.speed);
            //}
            //Console.WriteLine("{0} ha terminado la carrera!", h.name);


            //for (var i = 0; i < 600; i++)
            //{
            Console.WriteLine("Hola");
            h.sprite.Dispatcher.Invoke(new UpdateSpritePosition(h.UpdatePos), new object[] { 600 });
                //Thread.Sleep((int)20);
            //}
        }
    }
}
