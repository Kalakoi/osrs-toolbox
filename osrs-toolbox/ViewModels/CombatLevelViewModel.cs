using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class CombatLevelViewModel : CombatLevelModel
    {
        public CombatLevelViewModel()
        {
            InitializeVariables();
            InitializeCommands();
        }

        private void InitializeVariables()
        {
            UserName = string.Empty;
            Attack = 1;
            Strength = 1;
            Defense = 1;
            Hitpoints = 10;
            Ranged = 1;
            Prayer = 1;
            Magic = 1;
        }

        private void InitializeCommands()
        {
            LoadPlayer = new RelayCommand(DoLoadPlayer);
        }

        private void DoLoadPlayer(object obj)
        {
            Player p;
            try
            {
                p = WiseOldMan.GetPlayer(UserName);
            }
            catch
            {
                InitializeVariables();
                UserName = "User Not Found on Wise Old Man";
                return;
            }
            if (p.latestSnapshot is null)
            {
                InitializeVariables();
                UserName = "User Not Found on Wise Old Man";
                return;
            }
            Attack = p.latestSnapshot.data.skills.attack.level;
            Strength = p.latestSnapshot.data.skills.strength.level;
            Defense = p.latestSnapshot.data.skills.defence.level;
            Hitpoints = p.latestSnapshot.data.skills.hitpoints.level;
            Ranged = p.latestSnapshot.data.skills.ranged.level;
            Prayer = p.latestSnapshot.data.skills.prayer.level;
            Magic = p.latestSnapshot.data.skills.magic.level;
        }
    }
}
