using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace osrs_toolbox
{
    public class HomePageViewModel : HomePageModel
    {
        public HomePageViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            
        }

        private void InitializeCommands()
        {
            OpenCompetitionOverlaySettings = new RelayCommand(DoOpenCompetitionOverlaySettings);
        }

        private void DoOpenCompetitionOverlaySettings(object obj)
        {
            if (CompetitionOverlaySettingsView.Current != null)
            {
                CompetitionOverlaySettingsView.Current.Close();
                CompetitionOverlaySettingsView.Current = null;
            }
            else
            {
                CompetitionOverlaySettingsView cosv = new CompetitionOverlaySettingsView();
                cosv.Show();
            }
        }
    }
}
