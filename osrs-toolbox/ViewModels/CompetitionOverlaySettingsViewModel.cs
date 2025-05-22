using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class CompetitionOverlaySettingsViewModel : CompetitionOverlaySettingsModel
    {
        public CompetitionOverlaySettingsViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            CompetitionID = Properties.Settings.Default.LastCompetitionID;
            GroupID = Properties.Settings.Default.LastGroupID;
            PlayerName = Properties.Settings.Default.LastUserName;
            HideOtherPlayers = Properties.Settings.Default.LastHideOthers;
            HideZeroGained = Properties.Settings.Default.LastHideZeroGained;
        }

        private void InitializeCommands()
        {
            ToggleCompetitionOverlay = new RelayCommand(DoToggleCompetitionOverlay);
            ToggleCompetitionOverlayClickThrough = new RelayCommand(DoToggleCompetitionOverlayClickThrough);
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
                (cov.DataContext as CompetitionOverlayViewModel).HideZeroGained = HideZeroGained;
                cov.Show();
                Properties.Settings.Default.LastUserName = PlayerName;
                Properties.Settings.Default.LastGroupID = GroupID;
                Properties.Settings.Default.LastCompetitionID = CompetitionID;
                Properties.Settings.Default.LastHideOthers = HideOtherPlayers;
                Properties.Settings.Default.LastHideZeroGained = HideZeroGained;
                Properties.Settings.Default.Save();
            }
        }

        private void DoToggleCompetitionOverlayClickThrough(object obj)
        {
            if (CompetitionOverlayView.Current == null) { return; }
            (CompetitionOverlayView.Current as CompetitionOverlayView).MakeClickThrough();
        }
    }
}
