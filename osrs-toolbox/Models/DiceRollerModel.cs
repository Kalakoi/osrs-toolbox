using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osrs_toolbox
{
    public abstract class DiceRollerModel : ModelBase
    {
        private int _minValue;
        private int _maxValue;
        private int _numRolls;
        private bool _allowDuplicates;
        private string _rollResults;

        private ICommand _rollDice;

        public int MinValue
        {
            get { return _minValue; }
            set { SetProperty(ref _minValue, value, nameof(MinValue)); }
        }
        public int MaxValue
        {
            get { return _maxValue; }
            set { SetProperty(ref _maxValue, value, nameof(MaxValue)); }
        }
        public int NumRolls
        {
            get { return _numRolls; }
            set { SetProperty(ref _numRolls, value, nameof(NumRolls)); }
        }
        public bool AllowDuplicates
        {
            get { return _allowDuplicates; }
            set { SetProperty(ref _allowDuplicates, value, nameof(AllowDuplicates)); }
        }
        public string RollResults
        {
            get { return _rollResults; }
            set { SetProperty(ref _rollResults, value, nameof(RollResults)); }
        }

        public ICommand RollDice
        {
            get { return _rollDice; }
            set { SetProperty(ref _rollDice, value, nameof(RollDice)); }
        }
    }
}
