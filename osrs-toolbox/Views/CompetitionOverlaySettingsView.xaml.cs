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
    /// Interaction logic for CompetitionOverlaySettingsView.xaml
    /// </summary>
    public partial class CompetitionOverlaySettingsView : Window
    {
        public static CompetitionOverlaySettingsView Current;

        public CompetitionOverlaySettingsView()
        {
            InitializeComponent();
            Current = this;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Current = null;
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { this.DragMove(); }
        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            Current.Close();
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

        private void Toggle_Other_Players(object sender, MouseButtonEventArgs e)
        {
            (DataContext as CompetitionOverlaySettingsViewModel).HideOtherPlayers = !(DataContext as CompetitionOverlaySettingsViewModel).HideOtherPlayers;
        }

        private void Toggle_Zero_Gained(object sender, MouseButtonEventArgs e)
        {
            (DataContext as CompetitionOverlaySettingsViewModel).HideZeroGained = !(DataContext as CompetitionOverlaySettingsViewModel).HideZeroGained;
        }
    }
}
