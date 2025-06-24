using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class HiscoreLookupViewModel : HiscoreLookupModel
    {
        public HiscoreLookupViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            PlayerName = string.Empty;
            DisplayOption = "Skills";
            DisplayOptions = ["Skills", "Activities", "Bosses"];
            HiscoreInfo = new();
        }

        private void InitializeCommands()
        {
            LookupPlayer = new RelayCommand(DoPlayerLookup);
        }

        private async void DoPlayerLookup(object obj)
        {
            HiscoreInfo = new();
            PlayerInfoService pis = new(new());
            HiscoreInfo = await pis.GetPlayerInfoAsync(PlayerName).ConfigureAwait(false);
        }
    }
}
