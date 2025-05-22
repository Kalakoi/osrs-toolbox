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
    }
}
