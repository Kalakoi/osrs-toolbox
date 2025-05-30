﻿using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace osrs_toolbox
{
    public abstract class CompetitionOverlaySettingsModel : ModelBase
    {
        private int _competitionId = -1;
        private int _groupId = -1;
        private string _playerName = string.Empty;
        private bool _hideOtherPlayers = false;
        private bool _hideZeroKC = false;

        private ICommand _toggleCompetitionOverlay;
        private ICommand _toggleCompetitionOverlayClickThrough;

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
        public bool HideOtherPlayers
        {
            get { return _hideOtherPlayers; }
            set { SetProperty(ref _hideOtherPlayers, value, nameof(HideOtherPlayers)); OnPropertyChanged(nameof(OtherPlayersCheckboxImage)); }
        }
        public bool HideZeroGained
        {
            get { return _hideZeroKC; }
            set { SetProperty(ref _hideZeroKC, value, nameof(HideZeroGained)); OnPropertyChanged(nameof(HideZeroCheckboxImage)); }
        }
        public ImageSource OtherPlayersCheckboxImage => HideOtherPlayers ? new BitmapImage(new Uri(@"/Resources/stone-checkbox-checked.png", UriKind.Relative)) : new BitmapImage(new Uri(@"/Resources/stone-checkbox-unchecked.png", UriKind.Relative));
        public ImageSource HideZeroCheckboxImage => HideZeroGained ? new BitmapImage(new Uri(@"/Resources/stone-checkbox-checked.png", UriKind.Relative)) : new BitmapImage(new Uri(@"/Resources/stone-checkbox-unchecked.png", UriKind.Relative));

        public ICommand ToggleCompetitionOverlay
        {
            get { return _toggleCompetitionOverlay; }
            set { SetProperty(ref _toggleCompetitionOverlay, value, nameof(ToggleCompetitionOverlay)); }
        }
        public ICommand ToggleCompetitionOverlayClickThrough
        {
            get { return _toggleCompetitionOverlayClickThrough; }
            set { SetProperty(ref _toggleCompetitionOverlayClickThrough, value, nameof(ToggleCompetitionOverlayClickThrough)); }
        }
    }
}
