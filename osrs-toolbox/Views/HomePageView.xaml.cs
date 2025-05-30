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

namespace osrs_toolbox
{
    /// <summary>
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : Window
    {
        public static HomePageView Current;

        public HomePageView()
        {
            InitializeComponent();
            Current = this;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (Window w in Application.Current.Windows)
                w.Close();
            Application.Current.Shutdown();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { this.DragMove(); }
        }

        private void Close_App(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { Window_Closed(sender, e); }
        }

        private void Button_Hovered(object sender, MouseEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri(@"/Resources/wood-button-pressed.png", UriKind.Relative));
        }

        private void Button_Unhovered(object sender, MouseEventArgs e)
        {
            (sender as Image).Source = new BitmapImage(new Uri(@"/Resources/wood-button.png", UriKind.Relative));
        }

        private void Exit_Hovered(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = new SolidColorBrush(Colors.Red);
        }

        private void Exit_Unhovered(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = new SolidColorBrush(Colors.White);
        }
    }
}
