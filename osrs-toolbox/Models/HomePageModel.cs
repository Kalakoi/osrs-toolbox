using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace osrs_toolbox
{
    public abstract class HomePageModel : ModelBase
    {
        private ICommand _openCompetitionOverlaySettings;
        private ICommand _openDropChanceCalculator;
        private ICommand _openCombatLevelCalculator;
        private ICommand _openShopBuyoutCalculator;

        public ICommand OpenCompetitionOverlaySettings
        {
            get { return _openCompetitionOverlaySettings; }
            set { SetProperty(ref _openCompetitionOverlaySettings, value, nameof(OpenCompetitionOverlaySettings)); }
        }

        public ICommand OpenDropChanceCalculator
        {
            get { return _openDropChanceCalculator; }
            set { SetProperty(ref _openDropChanceCalculator, value, nameof(OpenDropChanceCalculator)); }
        }

        public ICommand OpenCombatLevelCalculator
        {
            get { return _openCombatLevelCalculator; }
            set { SetProperty(ref _openCombatLevelCalculator, value, nameof(OpenCombatLevelCalculator)); }
        }
        public ICommand OpenShopBuyoutCalculator
        {
            get { return _openShopBuyoutCalculator; }
            set { SetProperty(ref _openShopBuyoutCalculator, value, nameof(OpenShopBuyoutCalculator)); }
        }
    }
}
