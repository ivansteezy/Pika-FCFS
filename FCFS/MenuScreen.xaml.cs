using System;
using FCFS.src;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace FCFS
{
    public partial class MenuScreen : Page
    {
        public MenuScreen()
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
                                homeGif.Source = bitmapSource2;
                            }));
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                });
                th.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception thown in gif thread ERROR: ", ex.Message);
            }
        }

        private void GoToRaceScreen(object sender, RoutedEventArgs e)
        {
            var mainW = (MainWindow)Window.GetWindow(this);
            mainW.dataContent.Navigate(new RaceScreen());

            // code to trigger all threads

            //Console.WriteLine("A correr!");
            //Console.ReadLine();

            //var h1 = new Horse(3, new Thread(Horse.Run), "El lento", 1000);
            //var h2 = new Horse(1, new Thread(Horse.Run), "El medio", 500);
            //var h3 = new Horse(2, new Thread(Horse.Run), "El veloz", 250);

            //var list = new List<Horse>();
            //list.Add(h1);
            //list.Add(h2);
            //list.Add(h3);

            //var race = new Race(list);
            //race.BeginRace();
        }
    }
}
