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

        public ICommand OpenCompetitionOverlaySettings
        {
            get { return _openCompetitionOverlaySettings; }
            set { SetProperty(ref _openCompetitionOverlaySettings, value, nameof(OpenCompetitionOverlaySettings)); }
        }
    }
}
