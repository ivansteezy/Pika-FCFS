using FCFS.src;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FCFS
{
    static class Move
    {
        public static void MoveTo(this Image target, double newX, double newY)
        {
            
            var top = Canvas.GetTop(target);
            var left = Canvas.GetLeft(target);
            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(top, newY - top, TimeSpan.FromSeconds(3));
            DoubleAnimation anim2 = new DoubleAnimation(left, newX - left, TimeSpan.FromSeconds(3));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);
        }

        public static void SMoveTo(Image target)
        {
            for (var i = 0; i < 600; i++)
            {
                Canvas.SetLeft(target, i);
                // Thread.Sleep(20);
            }
        }
    }

    public partial class RaceScreen : Page
    {
        public RaceScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Move.MoveTo(pika1, 10, 600);
            //Move.MoveTo(pika2, 10, 600);
            //Move.MoveTo(pika3, 10, 600);
            //Move.MoveTo(pika4, 10, 600);
            //Move.MoveTo(pika5, 10, 600);

            //Move.SMoveTo(pika1);
            //Move.SMoveTo(pika2);
            //Move.SMoveTo(pika3);
            //Move.SMoveTo(pika4);
            //Move.SMoveTo(pika5);


            //this.Dispatcher.Invoke(() =>
            //{
                var h1 = new Horse(1, new Thread(Horse.Run), "Juan", 1000, pika1);
                var list = new List<Horse>();
                list.Add(h1);

                var race = new Race(list);
                race.BeginRace();
            //});
        }
    }
}
