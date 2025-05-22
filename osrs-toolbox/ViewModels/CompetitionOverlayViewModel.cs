using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace osrs_toolbox
{
    public class CompetitionOverlayViewModel : CompetitionOverlayModel
    {
        public CompetitionOverlayViewModel()
        {
            InitializeVariables();
            InitializeCommands();
            InitializeTimer();
        }

        public CompetitionOverlayViewModel(string Username, int GroupID, int CompetitionID)
        {
            InitializeVariables(Username, GroupID, CompetitionID);
            InitializeCommands();
            InitializeTimer();
        }

        private void InitializeVariables()
        {
            CompetitionID = 80030;
            GroupID = 11197;
            PlayerName = "kalakoi";
            GridOutput = new StackPanel();
            HideOtherPlayers = false;
            HideZeroGained = false;
        }

        private void InitializeVariables(string Username, int GroupID, int CompetitionID)
        {
            this.CompetitionID = CompetitionID;
            this.GroupID = GroupID;
            PlayerName = Username;
            GridOutput = new StackPanel();
            HideOtherPlayers = false;
            HideZeroGained = false;
        }

        private void InitializeCommands()
        {
            Update = new RelayCommand(DoUpdate);
        }

        private void InitializeTimer()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(5);
            dt.Tick += new EventHandler(TimerTick);
            dt.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DoUpdate(null);
        }

        private async void TimerTickAsync(object sender, EventArgs e)
        {
            await DoUpdateAsync(null);
        }

        private void DoUpdate(object obj)
        {
            GridOutput = new StackPanel();
            GridOutput.IsHitTestVisible = false;
            Competition c = new Competition();
            try
            {
                c = WiseOldMan.GetCompetition(CompetitionID);
            }
            catch
            {
                GridOutput.Children.Add(new OutlinedTextBlock()
                {
                    Text = "Failed to load competition data",
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = Brushes.White,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.ExtraBold,
                    TextWrapping = TextWrapping.Wrap,
                    IsHitTestVisible = false
                });
                OnPropertyChanged(nameof(GridOutput));
                return;
            }

            string KCorXP = "KC";
            if (Enum.GetNames<Skills>().Contains(c.metric.ToLower())) KCorXP = "XP";
            int GainedSum = 0;
            string TempOut = c.title;
            GridOutput.Children.Add(new OutlinedTextBlock()
            {
                Text = c.title,
                Margin = new Thickness(3),
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontWeight = FontWeights.ExtraBold,
                TextWrapping = TextWrapping.Wrap,
                IsHitTestVisible = false
            });
            foreach (CompetitionParticipation cp in c.participations)
            {
                StackPanel SubStack = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    IsHitTestVisible = false
                };

                Image typeImage = new Image();
                if (cp.player.type == "ironman")
                    typeImage.Source = ExternalResources.IronImage;
                else typeImage.Source = ExternalResources.MainImage;
                typeImage.IsHitTestVisible = false;

                SubStack.Children.Add(typeImage);

                SubStack.Children.Add(new OutlinedTextBlock()
                {
                    Text = cp.player.displayName,
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = PlayerName.ToUpper() == cp.player.displayName.ToUpper() ? Brushes.Green : Brushes.White,
                    FontSize = 20,
                    FontWeight = FontWeights.ExtraBold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    IsHitTestVisible = false
                });

                SubStack.Children.Add(new OutlinedTextBlock()
                {
                    Text = string.Format(" - {0} {1}", cp.progress.gained.ToString(), KCorXP),
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = Brushes.White,
                    FontSize = 20,
                    FontWeight = FontWeights.ExtraBold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    IsHitTestVisible = false
                });

                GainedSum += cp.progress.gained;

                bool AddToDisplay = true;
                if (HideOtherPlayers && PlayerName.ToUpper() != cp.player.displayName.ToUpper())
                    AddToDisplay = false;
                else if (HideZeroGained && cp.progress.gained == 0 && PlayerName.ToUpper() != cp.player.displayName.ToUpper())
                    AddToDisplay = false;

                if (AddToDisplay)
                    GridOutput.Children.Add(SubStack);
            }
            GridOutput.Children.Add(new OutlinedTextBlock()
            {
                Text = string.Format("Total {1}: {0}", GainedSum, KCorXP),
                Margin = new Thickness(3),
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                IsHitTestVisible = false
            });
            OnPropertyChanged(nameof(GridOutput));
        }

        private async Task DoUpdateAsync(object obj)
        {
            GridOutput = new StackPanel();
            Competition c = new Competition();
            try
            {
                c = await WiseOldMan.GetCompetitionAsync(CompetitionID).ConfigureAwait(false);
            }
            catch
            {
                GridOutput.Children.Add(new OutlinedTextBlock()
                {
                    Text = "Failed to load competition data",
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = Brushes.White,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.ExtraBold,
                    TextWrapping = TextWrapping.Wrap
                });
                OnPropertyChanged(nameof(GridOutput));
                return;
            }

            int KCSum = 0;
            string TempOut = c.title;
            GridOutput.Children.Add(new OutlinedTextBlock()
            {
                Text = c.title,
                Margin = new Thickness(3),
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontWeight = FontWeights.ExtraBold,
                TextWrapping = TextWrapping.Wrap
            });
            foreach (CompetitionParticipation cp in c.participations)
            {
                StackPanel SubStack = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };

                Image typeImage = new Image();
                if (cp.player.type == "ironman")
                    typeImage.Source = ExternalResources.IronImage;
                else typeImage.Source = ExternalResources.MainImage;
                typeImage.IsHitTestVisible = false;

                SubStack.Children.Add(typeImage);

                SubStack.Children.Add(new OutlinedTextBlock()
                {
                    Text = cp.player.displayName,
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = PlayerName.ToUpper() == cp.player.displayName.ToUpper() ? Brushes.Green : Brushes.White,
                    FontSize = 20,
                    FontWeight = FontWeights.ExtraBold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    IsHitTestVisible = false
                });

                SubStack.Children.Add(new OutlinedTextBlock()
                {
                    Text = string.Format(" - {0} KC", cp.progress.gained.ToString()),
                    Margin = new Thickness(3),
                    StrokeThickness = 1,
                    Stroke = Brushes.Black,
                    Fill = Brushes.White,
                    FontSize = 20,
                    FontWeight = FontWeights.ExtraBold,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    IsHitTestVisible = false
                });

                KCSum += cp.progress.gained;

                bool AddToDisplay = true;
                if (HideOtherPlayers && PlayerName.ToUpper() != cp.player.displayName.ToUpper())
                    AddToDisplay = false;
                else if (HideZeroGained && cp.progress.gained == 0 && PlayerName.ToUpper() != cp.player.displayName.ToUpper())
                    AddToDisplay = false;

                if (AddToDisplay)
                    GridOutput.Children.Add(SubStack);
            }
            GridOutput.Children.Add(new OutlinedTextBlock()
            {
                Text = string.Format("Total KC: {0}", KCSum),
                Margin = new Thickness(3),
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                IsHitTestVisible = false
            });
            OnPropertyChanged(nameof(GridOutput));
        }
    }
}
