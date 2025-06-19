using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osrs_toolbox
{
    public abstract class HiscoreLookupModel : ModelBase
    {
        private string _playerName;
        private string _displayOption;
        private string[] _displayOptions;
        private string _displayOutput;

        private ICommand _lookupPlayer;

        private PlayerInfo _hiscoreInfo;

        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty(ref _playerName, value, nameof(PlayerName)); }
        }
        public string DisplayOption
        {
            get { return _displayOption; }
            set { SetProperty(ref _displayOption, value, nameof(DisplayOption)); }
        }
        public string[] DisplayOptions
        {
            get { return _displayOptions; }
            set { SetProperty(ref _displayOptions, value, nameof(DisplayOptions)); }
        }
        public string DisplayOutput
        {
            get { return _displayOutput; }
            set { SetProperty(ref _displayOutput, value, nameof(DisplayOutput)); }
        }

        public ICommand LookupPlayer
        {
            get { return _lookupPlayer; }
            set { SetProperty(ref _lookupPlayer, value, nameof(LookupPlayer)); }
        }

        public PlayerInfo HiscoreInfo
        {
            get { return _hiscoreInfo; }
            set { SetProperty(ref _hiscoreInfo, value, nameof(HiscoreInfo)); }
        }
    }
}
