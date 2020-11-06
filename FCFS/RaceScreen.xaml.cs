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
        //TODO: migrate this method to the horse class
        //this code should be executed por back end threads
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

            var list = new List<Horse>();
            var h1 = new Horse(1, new Thread(Horse.Run), "Juan", 1000, pika1);
            list.Add(h1);

            var h2 = new Horse(2, new Thread(Horse.Run), "Pepe", 5000, pika2);
            list.Add(h2);

            //var h3 = new Horse(2, new Thread(Horse.Run), "Pepe", 1000, pika3);
            //list.Add(h3);

            //var h4 = new Horse(2, new Thread(Horse.Run), "Pepe", 1000, pika4);
            //list.Add(h4);

            //var h5 = new Horse(2, new Thread(Horse.Run), "Pepe", 1000, pika5);
            //list.Add(h5);

            var race = new Race(list);
            race.BeginRace();
        }
    }
}
