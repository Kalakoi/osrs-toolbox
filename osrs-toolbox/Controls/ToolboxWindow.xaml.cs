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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace osrs_toolbox
{
    /// <summary>
    /// Interaction logic for ToolboxWindow.xaml
    /// </summary>
    public partial class ToolboxWindow : UserControl
    {
        public ToolboxWindow()
        {
            InitializeComponent();
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { ((this.Parent as Grid).Parent as Window).DragMove(); }
        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            ((this.Parent as Grid).Parent as Window).Close();
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
