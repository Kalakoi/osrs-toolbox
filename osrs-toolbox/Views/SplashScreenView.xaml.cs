using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace osrs_toolbox
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        public static SplashScreenView Current;
        private DispatcherTimer timer;

        public SplashScreenView()
        {
            InitializeComponent();
            Current = this;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Application.Current.MainWindow = HomePageView.Current;
                HomePageView.Current.Show();
                this.Close();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            Application.Current.MainWindow = HomePageView.Current;
            HomePageView.Current.Show();
            this.Close();
            Current = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomePageView hp = new HomePageView();
            //TODO: Handle loading of data into datacontext, then open home screen
        }
    }
}
