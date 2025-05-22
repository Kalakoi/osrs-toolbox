using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace osrs_toolbox
{
    public abstract class CompetitionOverlayModel : ModelBase
    {
        private int _competitionId = -1;
        private int _groupId = -1;
        private string _playerName = string.Empty;
        private StackPanel _gridOutput = new StackPanel();
        private bool _hideOtherPlayers = false;
        private bool _hideZeroKC = false;

        private ICommand _update;

        public int CompetitionID
        {
            get { return _competitionId; }
            set { SetProperty(ref _competitionId, value, nameof(CompetitionID)); }
        }
        public int GroupID
        {
            get { return _groupId; }
            set { SetProperty(ref _groupId, value, nameof(GroupID)); }
        }
        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty(ref _playerName, value, nameof(PlayerName)); }
        }
        public StackPanel GridOutput
        {
            get { return _gridOutput; }
            set { SetProperty(ref _gridOutput, value, nameof(GridOutput)); }
        }
        public bool HideOtherPlayers
        {
            get { return _hideOtherPlayers; }
            set { SetProperty(ref _hideOtherPlayers, value, nameof(HideOtherPlayers)); }
        }
        public bool HideZeroKC
        {
            get { return _hideZeroKC; }
            set { SetProperty(ref _hideZeroKC, value, nameof(HideZeroKC)); }
        }

        public ICommand Update
        {
            get { return _update; }
            set { SetProperty(ref _update, value, nameof(Update)); }
        }
    }
}
