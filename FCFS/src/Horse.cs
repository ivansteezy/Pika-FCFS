using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            var top = Canvas.GetTop(this.sprite);
            var left = Canvas.GetLeft(this.sprite);
            TranslateTransform trans = new TranslateTransform();
            this.sprite.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(10, 600, TimeSpan.FromSeconds(this.speed/1000));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
        }

        public static void Run(object horse)
        {
            var h = (Horse)horse;
            h.sprite.Dispatcher.Invoke(new UpdateSpritePosition(h.UpdatePos), new object[] { 600 });
        }
    }
}
