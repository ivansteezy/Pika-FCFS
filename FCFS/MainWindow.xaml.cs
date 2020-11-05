using System.Windows;

namespace FCFS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataContent.Content = new MenuScreen();
        }
    }
}
