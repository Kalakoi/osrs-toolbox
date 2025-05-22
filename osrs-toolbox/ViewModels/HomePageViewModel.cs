using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CompetitionID = -1;
            GroupID = -1;
            PlayerName = string.Empty;
            HideOtherPlayers = false;
            HideZeroKC = false;
        }

        private void InitializeCommands()
        {
            ToggleCompetitionOverlay = new RelayCommand(DoToggleCompetitionOverlay);
        }

        private void DoToggleCompetitionOverlay(object obj)
        {
            if (CompetitionOverlayView.Current != null)
                CompetitionOverlayView.Current.Close();
            else
            {
                CompetitionOverlayView cov = new CompetitionOverlayView();
            }
        }
    }
}
