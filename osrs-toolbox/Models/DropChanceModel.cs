using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace osrs_toolbox
{
    public abstract class DropChanceModel : ModelBase
    {
        private double _dropRate;
        private int _currentKC;

        private double _chanceAtCurrent;
        private int _kcForFifty;
        private int _kcForNinety;

        private double _chanceCheck;

        private int _kcForChanceCheck;

        public double DropRate
        {
            get { return _dropRate; }
            set 
            { 
                SetProperty(ref _dropRate, value, nameof(DropRate)); 
                OnPropertyChanged(nameof(ChanceAtCurrent)); 
                OnPropertyChanged(nameof(KCForFifty)); 
                OnPropertyChanged(nameof(KCForNinety));
                OnPropertyChanged(nameof(KCForChanceCheck));
            }
        }
        public int CurrentKC
        {
            get { return _currentKC; }
            set
            {
                SetProperty(ref _currentKC, value, nameof(CurrentKC));
                OnPropertyChanged(nameof(ChanceAtCurrent));
                OnPropertyChanged(nameof(KCForFifty));
                OnPropertyChanged(nameof(KCForNinety));
            }
        }

        public double ChanceAtCurrent
        {
            get
            {
                double rate = DropRate > 1 ? (1 / DropRate) : DropRate;
                return 1 - Math.Pow(1 - rate,CurrentKC);
            }
        }
        public int KCForFifty
        {
            get
            {
                double rate = DropRate > 1 ? (1 / DropRate) : DropRate;
                double kc = Math.Log(1 / 2) / Math.Log(1 - rate);
                return (int)Math.Round(kc, MidpointRounding.AwayFromZero);
            }
        }
        public int KCForNinety
        {
            get
            {
                double rate = DropRate > 1 ? (1 / DropRate) : DropRate;
                double kc = Math.Log(1 / 10) / Math.Log(1 - rate);
                return (int)Math.Ceiling(kc);
            }
        }

        public double ChanceCheck
        {
            get { return _chanceCheck; }
            set
            {
                SetProperty(ref _chanceCheck, value, nameof(ChanceCheck));
                OnPropertyChanged(nameof(KCForChanceCheck));
            }
        }

        public int KCForChanceCheck
        {
            get
            {
                double rate = DropRate > 1 ? (1 / DropRate) : DropRate;
                double chance = ChanceCheck > 1 ? (ChanceCheck / 100) : ChanceCheck;
                double kc = Math.Log(1 - chance) / Math.Log(1 - rate);
                return (int)Math.Ceiling(kc);
            }
        }
    }
}
