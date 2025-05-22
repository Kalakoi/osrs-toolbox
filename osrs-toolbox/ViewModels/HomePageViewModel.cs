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
            {
                CompetitionOverlayView.Current.Close();
                CompetitionOverlayView.Current = null;
            }
            else
            {
                CompetitionOverlayView cov = new CompetitionOverlayView();
                (cov.DataContext as CompetitionOverlayViewModel).PlayerName = PlayerName;
                (cov.DataContext as CompetitionOverlayViewModel).GroupID = GroupID;
                (cov.DataContext as CompetitionOverlayViewModel).CompetitionID = CompetitionID;
                (cov.DataContext as CompetitionOverlayViewModel).HideOtherPlayers = HideOtherPlayers;
                (cov.DataContext as CompetitionOverlayViewModel).HideZeroKC = HideZeroKC;
                cov.Show();
            }
        }
    }
}
