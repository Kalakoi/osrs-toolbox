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
            OpenDropChanceCalculator = new RelayCommand(DoOpenDropChanceCalculator);
            OpenCombatLevelCalculator = new RelayCommand(DoOpenCombatLevelCalculator);
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

        private void DoOpenDropChanceCalculator(object obj)
        {
            if (DropChanceView.Current != null)
            {
                DropChanceView.Current.Close();
                DropChanceView.Current = null;
            }
            else
            {
                DropChanceView dcv = new DropChanceView();
                dcv.Show();
            }
        }

        private void DoOpenCombatLevelCalculator(object obj)
        {
            if (CombatLevelView.Current != null)
            {
                CombatLevelView.Current.Close();
                CombatLevelView.Current = null;
            }
            else
            {
                CombatLevelView clv = new CombatLevelView();
                clv.Show();
            }
        }
    }
}
