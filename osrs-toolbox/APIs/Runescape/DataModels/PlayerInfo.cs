using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace osrs_toolbox
{
    public class PlayerInfo
    {
        private static readonly Skill InitialSkillState = new Skill { Rank = -1, Level = 1, Experience = 1 };
        private static readonly Activity InitialActivityState = new Activity { Rank = -1, Score = -1 };
        private static readonly Boss InitialBossState = new Boss { Rank = -1, Kills = -1 };

        public string Name { get; set; } = "";
        public PlayerInfoStatus Status { get; internal set; } = PlayerInfoStatus.Unknown;
        public PlayerType AccountType { get; internal set; } = PlayerType.Unknown;

        //skills
        public Skill Overall { get; set; } = InitialSkillState;
        public Skill Attack { get; set; } = InitialSkillState;
        public Skill Defence { get; set; } = InitialSkillState;
        public Skill Strength { get; set; } = InitialSkillState;
        public Skill Hitpoints { get; set; } = InitialSkillState;
        public Skill Ranged { get; set; } = InitialSkillState;
        public Skill Prayer { get; set; } = InitialSkillState;
        public Skill Magic { get; set; } = InitialSkillState;
        public Skill Cooking { get; set; } = InitialSkillState;
        public Skill Woodcutting { get; set; } = InitialSkillState;
        public Skill Fletching { get; set; } = InitialSkillState;
        public Skill Fishing { get; set; } = InitialSkillState;
        public Skill Firemaking { get; set; } = InitialSkillState;
        public Skill Crafting { get; set; } = InitialSkillState;
        public Skill Smithing { get; set; } = InitialSkillState;
        public Skill Mining { get; set; } = InitialSkillState;
        public Skill Herblore { get; set; } = InitialSkillState;
        public Skill Agility { get; set; } = InitialSkillState;
        public Skill Thieving { get; set; } = InitialSkillState;
        public Skill Slayer { get; set; } = InitialSkillState;
        public Skill Farming { get; set; } = InitialSkillState;
        public Skill Runecrafting { get; set; } = InitialSkillState;
        public Skill Hunter { get; set; } = InitialSkillState;
        public Skill Construction { get; set; } = InitialSkillState;

        //minigames
        public Activity LeaguePoints { get; set; } = InitialActivityState;
        public Activity BountyHunterRogues { get; set; } = InitialActivityState;
        public Activity BountyHunter { get; set; } = InitialActivityState;
        public Activity BountyHunterRoguesLegacy { get; set; } = InitialActivityState;
        public Activity BountyHunterLegacy { get; set; } = InitialActivityState;
        public Activity DeadManMode { get; set; } = InitialActivityState;
        public Activity TotalCluesScrolls { get; set; } = InitialActivityState;
        public Activity BeginnerClueScrolls { get; set; } = InitialActivityState;
        public Activity EasyClueScrolls { get; set; } = InitialActivityState;
        public Activity MediumClueScrolls { get; set; } = InitialActivityState;
        public Activity HardClueScrolls { get; set; } = InitialActivityState;
        public Activity EliteClueScrolls { get; set; } = InitialActivityState;
        public Activity MasterClueScrolls { get; set; } = InitialActivityState;
        public Activity LastManStanding { get; set; } = InitialActivityState;
        public Activity PvPArena { get; set; } = InitialActivityState;
        public Activity SoulWarsZeal { get; set; } = InitialActivityState;
        public Activity RiftsClosed { get; set; } = InitialActivityState;
        public Activity ColosseumGlory { get; set; } = InitialActivityState;
        public Activity CollectionsLogged { get; set; } = InitialActivityState;

        //bosses
        public Boss AbyssalSire { get; set; } = InitialBossState;
        public Boss AlchemicalHydra { get; set; } = InitialBossState;
        public Boss Amoxliatl { get; set; } = InitialBossState;
        public Boss Araxxor { get; set; } = InitialBossState;
        public Boss Artio { get; set; } = InitialBossState;
        public Boss BarrowsChests { get; set; } = InitialBossState;
        public Boss Bryophyta { get; set; } = InitialBossState;
        public Boss Callisto { get; set; } = InitialBossState;
        public Boss Calvarion { get; set; } = InitialBossState;
        public Boss Cerberus { get; set; } = InitialBossState;
        public Boss ChambersofXeric { get; set; } = InitialBossState;
        public Boss ChambersofXericChallengeMode { get; set; } = InitialBossState;
        public Boss ChaosElemental { get; set; } = InitialBossState;
        public Boss ChaosFanatic { get; set; } = InitialBossState;
        public Boss CommanderZilyana { get; set; } = InitialBossState;
        public Boss CorporealBeast { get; set; } = InitialBossState;
        public Boss CrazyArchaeologist { get; set; } = InitialBossState;
        public Boss DagannothPrime { get; set; } = InitialBossState;
        public Boss DagannothRex { get; set; } = InitialBossState;
        public Boss DagannothSupreme { get; set; } = InitialBossState;
        public Boss DerangedArchaeologist { get; set; } = InitialBossState;
        public Boss DukeSucellus { get; set; } = InitialBossState;
        public Boss GeneralGraardor { get; set; } = InitialBossState;
        public Boss GiantMole { get; set; } = InitialBossState;
        public Boss GrotesqueGuardians { get; set; } = InitialBossState;
        public Boss Hespori { get; set; } = InitialBossState;
        public Boss KalphiteQueen { get; set; } = InitialBossState;
        public Boss KingBlackDragon { get; set; } = InitialBossState;
        public Boss Kraken { get; set; } = InitialBossState;
        public Boss Kreearra { get; set; } = InitialBossState;
        public Boss KrilTsutsaroth { get; set; } = InitialBossState;
        public Boss MoonsofPeril { get; set; } = InitialBossState;
        public Boss Mimic { get; set; } = InitialBossState;
        public Boss Nex { get; set; } = InitialBossState;
        public Boss Nightmare { get; set; } = InitialBossState;
        public Boss PhosanisNightmare { get; set; } = InitialBossState;
        public Boss Obor { get; set; } = InitialBossState;
        public Boss PhantomMuspah { get; set; } = InitialBossState;
        public Boss Sarachnis { get; set; } = InitialBossState;
        public Boss Scorpia { get; set; } = InitialBossState;
        public Boss Scurrius { get; set; } = InitialBossState;
        public Boss Skotizo { get; set; } = InitialBossState;
        public Boss SolHeredit { get; set; } = InitialBossState;
        public Boss Spindel { get; set; } = InitialBossState;
        public Boss Tempoross { get; set; } = InitialBossState;
        public Boss Gauntlet { get; set; } = InitialBossState;
        public Boss CorruptedGauntlet { get; set; } = InitialBossState;
        public Boss Hueycoatl { get; set; } = InitialBossState;
        public Boss Leviathan { get; set; } = InitialBossState;
        public Boss RoyalTitans { get; set; } = InitialBossState;
        public Boss Whisperer { get; set; } = InitialBossState;
        public Boss TheatreofBlood { get; set; } = InitialBossState;
        public Boss TheatreofBloodHardMode { get; set; } = InitialBossState;
        public Boss ThermonuclearSmokeDevil { get; set; } = InitialBossState;
        public Boss TombsOfAmascut { get; set; } = InitialBossState;
        public Boss TombsOfAmascutExpertMode { get; set; } = InitialBossState;
        public Boss Zuk { get; set; } = InitialBossState;
        public Boss Jad { get; set; } = InitialBossState;
        public Boss Vardorvis { get; set; } = InitialBossState;
        public Boss Venenatis { get; set; } = InitialBossState;
        public Boss Vetion { get; set; } = InitialBossState;
        public Boss Vorkath { get; set; } = InitialBossState;
        public Boss Wintertodt { get; set; } = InitialBossState;
        public Boss Yama { get; set; } = InitialBossState;
        public Boss Zalcano { get; set; } = InitialBossState;
        public Boss Zulrah { get; set; } = InitialBossState;

        public PlayerInfo() { }

        //returns all info in a big string.
        public string GetAllValuesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Player Name : {Name} \n");
            // retrieve the property information of the Player Info Class
            PropertyInfo[] properties = typeof(PlayerInfo).GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(Skill) || info.PropertyType == typeof(Activity))
                {
                    // gets the value of the PropertyInfo (Skill/Minigame) and returns its Properties
                    PropertyInfo[] SkillProperties = info.GetValue(this).GetType().GetProperties();
                    //Skill Name
                    sb.Append($"{info.Name} : ");
                    // Add the Minigame/Skill Properties into the sb
                    foreach (PropertyInfo SkillInfo in SkillProperties)
                    {
                        sb.Append($"{SkillInfo.Name} : {SkillInfo.GetValue(info.GetValue(this))}, ");
                    }
                    sb.Append("\n");
                }
            }
            return sb.ToString();
        }

        //IEnumerable for looping over all Skills
        public IEnumerable<Skill> Skills()
        {
            PropertyInfo[] properties = typeof(PlayerInfo).GetProperties();

            foreach (PropertyInfo info in properties.Where(info => info.PropertyType == typeof(Skill)))
            {
                Skill skill = (Skill)info.GetValue(this, null);
                yield return skill;
            }
        }

        //IEnumberable for looping over all Minigames
        public IEnumerable<Activity> Minigames()
        {
            PropertyInfo[] properties = typeof(PlayerInfo).GetProperties();

            foreach (PropertyInfo info in properties.Where(info => info.PropertyType == typeof(Activity)))
            {
                Activity skill = (Activity)info.GetValue(this, null);
                yield return skill;
            }
        }

        //IEnumberable for looping over all Bosses
        public IEnumerable<Boss> Bosses()
        {
            PropertyInfo[] properties = typeof(PlayerInfo).GetProperties();

            foreach (PropertyInfo info in properties.Where(info => info.PropertyType == typeof(Boss)))
            {
                Boss skill = (Boss)info.GetValue(this, null);
                yield return skill;
            }
        }
    }
}
