using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osrs_toolbox
{
    public abstract class CombatLevelModel : ModelBase
    {
        private string _userName;
        private int _attack;
        private int _strength;
        private int _hitpoints;
        private int _defense;
        private int _ranged;
        private int _magic;
        private int _prayer;

        private ICommand _loadPlayer;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value, nameof(UserName)); }
        }
        public int Attack
        {
            get { return _attack; }
            set 
            { 
                SetProperty(ref _attack, value, nameof(Attack));
                UpdateOutput();
            }
        }
        public int Strength
        {
            get { return _strength; }
            set 
            { 
                SetProperty(ref _strength, value, nameof(Strength));
                UpdateOutput();
            }
        }
        public int Hitpoints
        {
            get { return _hitpoints; }
            set
            {
                SetProperty(ref _hitpoints, value, nameof(Hitpoints));
                UpdateOutput();
            }
        }
        public int Defense
        {
            get { return _defense; }
            set
            {
                SetProperty(ref _defense, value, nameof(Defense));
                UpdateOutput();
            }
        }
        public int Ranged
        {
            get { return _ranged; }
            set
            {
                SetProperty(ref _ranged, value, nameof(Ranged));
                UpdateOutput();
            }
        }
        public int Magic
        {
            get { return _magic; }
            set
            {
                SetProperty(ref _magic, value, nameof(Magic));
                UpdateOutput();
            }
        }
        public int Prayer
        {
            get { return _prayer; }
            set
            {
                SetProperty(ref _prayer, value, nameof(Prayer));
                UpdateOutput();
            }
        }

        public ICommand LoadPlayer
        {
            get { return _loadPlayer; }
            set { SetProperty(ref _loadPlayer, value, nameof(LoadPlayer)); }
        }

        private void UpdateOutput()
        {
            OnPropertyChanged(nameof(CombatLevel));
            OnPropertyChanged(nameof(NextLevel));
            OnPropertyChanged(nameof(NeededAttack));
            OnPropertyChanged(nameof(NeededStrength));
            OnPropertyChanged(nameof(NeededDefense));
            OnPropertyChanged(nameof(NeededHitpoints));
            OnPropertyChanged(nameof(NeededRanged));
            OnPropertyChanged(nameof(NeededMagic));
            OnPropertyChanged(nameof(NeededPrayer));
        }

        public double CombatLevel => Math.Floor(0.25d * (Defense + Hitpoints + Math.Floor(Prayer / 2d)) + (0.325 * Math.Max(Math.Max(Attack + Strength, Ranged * 1.5d), Magic * 1.5d)));
        public double NextLevel => Math.Min(126, CombatLevel + 1);
        public string NeededAttack
        {
            get
            {
                double AttackCalc = Math.Ceiling((NextLevel - (0.25d * Defense) - (0.25d * Hitpoints) - (0.25d * Math.Floor(Prayer / 2d)) - (0.325 * Strength)) / 0.325d) - Attack;
                if (AttackCalc + Attack > 99) return "-";
                else return AttackCalc.ToString();
            }
        }
        public string NeededStrength
        {
            get
            {
                double StrengthCalc = Math.Ceiling((NextLevel - (0.25d * Defense) - (0.25d * Hitpoints) - (0.25d * Math.Floor(Prayer / 2d)) - (0.325 * Attack)) / 0.325d) - Strength;
                if (StrengthCalc + Strength > 99) return "-";
                else return StrengthCalc.ToString();
            }
        }
        public string NeededDefense
        {
            get
            {
                double DefenseCalc = Math.Ceiling((NextLevel - (0.25 * Hitpoints) - (0.25 * Math.Floor(Prayer / 2d)) - (0.325 * Math.Max(Math.Max(Attack + Strength, Ranged * 1.5d), Magic * 1.5d))) / 0.25) - Defense;
                if (DefenseCalc + Defense > 99) return "-";
                else return DefenseCalc.ToString();
            }
        }
        public string NeededHitpoints
        {
            get
            {
                double HitpointsCalc = Math.Ceiling((NextLevel - (0.25d * Defense) - (0.25d * Math.Floor(Prayer / 2d)) - (0.325 * Math.Max(Math.Max(Attack + Strength, Ranged * 1.5d), Magic * 1.5d))) / 0.25d) - Hitpoints;
                if (HitpointsCalc + Hitpoints > 99) return "-";
                else return HitpointsCalc.ToString();
            }
        }
        public string NeededRanged
        {
            get
            {
                double RangedCalc = Math.Ceiling((NextLevel - (0.25 * (Defense + Hitpoints + Math.Floor(Prayer / 2d)))) / 0.4875d) - Ranged;
                if (RangedCalc + Ranged > 99) return "-";
                else return RangedCalc.ToString();
            }
        }
        public string NeededMagic
        {
            get
            {
                double MagicCalc = Math.Ceiling((NextLevel - (0.25 * (Defense + Hitpoints + Math.Floor(Prayer / 2d)))) / 0.4875d) - Magic;
                if (MagicCalc + Magic > 99) return "-";
                else return MagicCalc.ToString();
            }
        }
        public string NeededPrayer
        {
            get
            {
                double PrayerCalc = Math.Ceiling((NextLevel - (0.25d * Hitpoints) - (0.25d * Defense) - (0.325 * Math.Max(Math.Max(Attack + Strength, Ranged * 1.5d), Magic * 1.5d))) / 0.125d) - Prayer;
                if (PrayerCalc + Prayer > 99) return "-";
                else return PrayerCalc.ToString();
            }
        }
    }
}
