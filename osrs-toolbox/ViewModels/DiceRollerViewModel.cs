using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class DiceRollerViewModel : DiceRollerModel
    {
        public DiceRollerViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            MinValue = 0;
            MaxValue = 100;
            NumRolls = 1;
            AllowDuplicates = true;
            RollResults = string.Empty;
        }

        private void InitializeCommands()
        {
            RollDice = new RelayCommand(DoRollDice);
        }

        private async void DoRollDice(object obj)
        {
            RollResults = "Rolling Dice...";
            await Task.Delay(10);
            int[] Rolls = await Random.GetRandomIntegersAsync(MinValue, MaxValue, NumRolls, AllowDuplicates).ConfigureAwait(false);
            bool First = true;
            RollResults = string.Empty;
            foreach (int Roll in Rolls)
            {
                RollResults += string.Format("{0}{1}", First ? "" : ", ", Roll.ToString());
                First = false;
            }
        }
    }
}
