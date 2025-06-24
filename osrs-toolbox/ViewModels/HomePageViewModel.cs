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
            OpenShopBuyoutCalculator = new RelayCommand(DoOpenShopBuyoutCalculator);
            OpenAPITest = new RelayCommand(DoOpenAPITest);
            OpenDiceRoller = new RelayCommand(DoOpenDiceRoller);
            OpenHiscoreLookup = new RelayCommand(DoOpenHiscoreLookup);
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

        private void DoOpenShopBuyoutCalculator(object obj)
        {
            if (ShopBuyoutView.Current != null)
            {
                ShopBuyoutView.Current.Close();
                ShopBuyoutView.Current = null;
            }
            else
            {
                ShopBuyoutView sbv = new ShopBuyoutView();
                sbv.Show();
            }
        }

        private void DoOpenAPITest(object obj)
        {
            if (APITestView.Current != null) 
            {
                APITestView.Current.Close();
                APITestView.Current = null;
            }
            else
            {
                APITestView atv = new APITestView();
                atv.Show();
            }
        }

        private void DoOpenDiceRoller(object obj)
        {
            if (DiceRollerView.Current != null)
            {
                DiceRollerView.Current.Close();
                DiceRollerView.Current = null;
            }
            else
            {
                DiceRollerView drv = new DiceRollerView();
                drv.Show();
            }
        }

        private void DoOpenHiscoreLookup(object obj)
        {
            if (HiscoreLookupView.Current != null)
            {
                HiscoreLookupView.Current.Close();
                HiscoreLookupView.Current = null;
            }
            else
            {
                HiscoreLookupView hlv = new HiscoreLookupView();
                hlv.Show();
            }
        }
    }
}
