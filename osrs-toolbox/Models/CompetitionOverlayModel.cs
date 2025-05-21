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
        private string _testOutput = string.Empty;
        private StackPanel _gridOutput = new StackPanel();
        private Visibility _controlsVisible = Visibility.Visible;
        private string _toggleButtonText = string.Empty;
        private bool _hideOtherPlayers = false;
        private bool _hideZeroKC = false;

        private ICommand _update;
        private ICommand _toggleVisibility;
        private ICommand _closeApp;

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
        public string TestOutput
        {
            get { return _testOutput; }
            set { SetProperty(ref _testOutput, value, nameof(TestOutput)); }
        }
        public StackPanel GridOutput
        {
            get { return _gridOutput; }
            set { SetProperty(ref _gridOutput, value, nameof(GridOutput)); }
        }
        public Visibility ControlsVisible
        {
            get { return _controlsVisible; }
            set { SetProperty(ref _controlsVisible, value, nameof(ControlsVisible)); }
        }
        public string ToggleButtonText
        {
            get { return _toggleButtonText; }
            set { SetProperty(ref _toggleButtonText, value, nameof(ToggleButtonText)); }
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
        public ICommand ToggleVisibility
        {
            get { return _toggleVisibility; }
            set { SetProperty(ref _toggleVisibility, value, nameof(ToggleVisibility)); }
        }
        public ICommand CloseApp
        {
            get { return _closeApp; }
            set { SetProperty(ref _closeApp, value, nameof(CloseApp)); }
        }
    }
}
