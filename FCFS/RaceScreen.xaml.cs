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
using System.Windows.Media.Imaging;

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

            Uri myUri = new Uri(@"..\..\img\pika.gif", UriKind.RelativeOrAbsolute);
            GifBitmapDecoder decoder2 = new GifBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2;
            int frameCount = decoder2.Frames.Count;

            try
            {
                Thread th = new Thread(() => {
                    while (true)
                    {
                        for (int i = 0; i < frameCount; i++)
                        {
                            this.Dispatcher.Invoke(new Action(delegate ()
                            {
                                bitmapSource2 = decoder2.Frames[i];
                                pika1.Source = bitmapSource2;
                                pika2.Source = bitmapSource2;
                                pika3.Source = bitmapSource2;
                                pika4.Source = bitmapSource2;
                                pika5.Source = bitmapSource2;
                            }));
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                });
                th.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thown in gif thread ERROR: ", ex.Message);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var rnd = GenerateRandomNumbers();

            var list = new List<Horse>();
            var h1 = new Horse(1, new Thread(Horse.Run), "Pika1", rnd[0], pika1);
            list.Add(h1);

            var h2 = new Horse(2, new Thread(Horse.Run), "Pika2", rnd[1], pika2);
            list.Add(h2);

            var h3 = new Horse(3, new Thread(Horse.Run), "Pika3", rnd[2], pika3);
            list.Add(h3);

            var h4 = new Horse(4, new Thread(Horse.Run), "Pika4", rnd[3], pika4);
            list.Add(h4);

            var h5 = new Horse(1, new Thread(Horse.Run), "Pika5", rnd[4], pika5);
            list.Add(h5);

            var race = new Race(list);
            race.BeginRace();
        }

        private List<uint> GenerateRandomNumbers()
        {
            Random rand = new Random();
            var ints = Enumerable.Range(1, 10)
                                         .Select(i => new Tuple<uint, uint>((uint)rand.Next(10), (uint)i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => (i.Item2 * 1000)).ToList();
            return ints;
        }
    }
}
