using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osrs_toolbox
{
    public abstract class HiscoreLookupModel : ModelBase
    {
        private string _playerName;
        private string _displayOption;
        private string[] _displayOptions;

        private ICommand _lookupPlayer;

        private PlayerInfo _hiscoreInfo;

        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty(ref _playerName, value, nameof(PlayerName)); }
        }
        public string DisplayOption
        {
            get { return _displayOption; }
            set { SetProperty(ref _displayOption, value, nameof(DisplayOption));  OnPropertyChanged(nameof(DisplayOutput)); }
        }
        public string[] DisplayOptions
        {
            get { return _displayOptions; }
            set { SetProperty(ref _displayOptions, value, nameof(DisplayOptions)); }
        }
        public string DisplayOutput
        {
            get 
            {
                if (HiscoreInfo.Status != PlayerInfoStatus.Success) 
                    return string.Empty;
                string Output = HiscoreInfo.Name;
                switch (DisplayOption)
                {
                    case "Skills":
                        Output += string.Format("\nOverall Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Overall.Level, HiscoreInfo.Overall.Experience, HiscoreInfo.Overall.Rank);
                        Output += string.Format("\nAttack Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Attack.Level, HiscoreInfo.Attack.Experience, HiscoreInfo.Attack.Rank);
                        Output += string.Format("\nDefence Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Defence.Level, HiscoreInfo.Defence.Experience, HiscoreInfo.Defence.Rank);
                        Output += string.Format("\nStrength Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Strength.Level, HiscoreInfo.Strength.Experience, HiscoreInfo.Strength.Rank);
                        Output += string.Format("\nHitpoints Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Hitpoints.Level, HiscoreInfo.Hitpoints.Experience, HiscoreInfo.Hitpoints.Rank);
                        Output += string.Format("\nRanged Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Ranged.Level, HiscoreInfo.Ranged.Experience, HiscoreInfo.Ranged.Rank);
                        Output += string.Format("\nPrayer Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Prayer.Level, HiscoreInfo.Prayer.Experience, HiscoreInfo.Prayer.Rank);
                        Output += string.Format("\nMagic Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Magic.Level, HiscoreInfo.Magic.Experience, HiscoreInfo.Magic.Rank);
                        Output += string.Format("\nCooking Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Cooking.Level, HiscoreInfo.Cooking.Experience, HiscoreInfo.Cooking.Rank);
                        Output += string.Format("\nWoodcutting Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Woodcutting.Level, HiscoreInfo.Woodcutting.Experience, HiscoreInfo.Woodcutting.Rank);
                        Output += string.Format("\nFletching Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Fletching.Level, HiscoreInfo.Fletching.Experience, HiscoreInfo.Fletching.Rank);
                        Output += string.Format("\nFishing Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Fishing.Level, HiscoreInfo.Fishing.Experience, HiscoreInfo.Fishing.Rank);
                        Output += string.Format("\nFiremaking Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Firemaking.Level, HiscoreInfo.Firemaking.Experience, HiscoreInfo.Firemaking.Rank);
                        Output += string.Format("\nCrafting Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Crafting.Level, HiscoreInfo.Crafting.Experience, HiscoreInfo.Crafting.Rank);
                        Output += string.Format("\nSmithing Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Smithing.Level, HiscoreInfo.Smithing.Experience, HiscoreInfo.Smithing.Rank);
                        Output += string.Format("\nMining Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Mining.Level, HiscoreInfo.Mining.Experience, HiscoreInfo.Mining.Rank);
                        Output += string.Format("\nHerblore Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Herblore.Level, HiscoreInfo.Herblore.Experience, HiscoreInfo.Herblore.Rank);
                        Output += string.Format("\nAgility Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Agility.Level, HiscoreInfo.Agility.Experience, HiscoreInfo.Agility.Rank);
                        Output += string.Format("\nThieving Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Thieving.Level, HiscoreInfo.Thieving.Experience, HiscoreInfo.Thieving.Rank);
                        Output += string.Format("\nSlayer Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Slayer.Level, HiscoreInfo.Slayer.Experience, HiscoreInfo.Slayer.Rank);
                        Output += string.Format("\nFarming Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Farming.Level, HiscoreInfo.Farming.Experience, HiscoreInfo.Farming.Rank);
                        Output += string.Format("\nRunecrafting Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Runecrafting.Level, HiscoreInfo.Runecrafting.Experience, HiscoreInfo.Runecrafting.Rank);
                        Output += string.Format("\nHunter Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Hunter.Level, HiscoreInfo.Hunter.Experience, HiscoreInfo.Hunter.Rank);
                        Output += string.Format("\nConstruction Level: {0} XP: {1} Rank: {2}", HiscoreInfo.Construction.Level, HiscoreInfo.Construction.Experience, HiscoreInfo.Construction.Rank);
                        break;
                    case "Activities":
                        Output += string.Format("\nLeague Points: {0} Rank: {1}", HiscoreInfo.LeaguePoints.Score, HiscoreInfo.LeaguePoints.Rank);
                        Output += string.Format("\nBounty Hunter Rogues Score: {0} Rank: {1}", HiscoreInfo.BountyHunterRogues.Score, HiscoreInfo.BountyHunterRogues.Rank);
                        Output += string.Format("\nBounty Hunter Score: {0} Rank: {1}", HiscoreInfo.BountyHunter.Score, HiscoreInfo.BountyHunter.Rank);
                        Output += string.Format("\nBounty Hunter Rogues Legacy Score: {0} Rank: {1}", HiscoreInfo.BountyHunterRoguesLegacy.Score, HiscoreInfo.BountyHunterRoguesLegacy.Rank);
                        Output += string.Format("\nBounty Hunter Legacy Score: {0} Rank: {1}", HiscoreInfo.BountyHunterLegacy.Score, HiscoreInfo.BountyHunterLegacy.Rank);
                        Output += string.Format("\nDead Man Mode Points: {0} Rank: {1}", HiscoreInfo.DeadManMode.Score, HiscoreInfo.DeadManMode.Rank);
                        Output += string.Format("\nTotal Clue Scrolls: {0} Rank: {1}", HiscoreInfo.TotalCluesScrolls.Score, HiscoreInfo.TotalCluesScrolls.Rank);
                        Output += string.Format("\nBeginner Clue Scrolls: {0} Rank: {1}", HiscoreInfo.BeginnerClueScrolls.Score, HiscoreInfo.BeginnerClueScrolls.Rank);
                        Output += string.Format("\nEasy Clue Scrolls: {0} Rank: {1}", HiscoreInfo.EasyClueScrolls.Score, HiscoreInfo.EasyClueScrolls.Rank);
                        Output += string.Format("\nMedium Clue Scrolls: {0} Rank: {1}", HiscoreInfo.MediumClueScrolls.Score, HiscoreInfo.MediumClueScrolls.Rank);
                        Output += string.Format("\nHard Clue Scrolls: {0} Rank: {1}", HiscoreInfo.HardClueScrolls.Score, HiscoreInfo.HardClueScrolls.Rank);
                        Output += string.Format("\nElite Clue Scrolls: {0} Rank: {1}", HiscoreInfo.EliteClueScrolls.Score, HiscoreInfo.EliteClueScrolls.Rank);
                        Output += string.Format("\nMaster Clue Scrolls: {0} Rank: {1}", HiscoreInfo.MasterClueScrolls.Score, HiscoreInfo.MasterClueScrolls.Rank);
                        Output += string.Format("\nLast Man Standing Score: {0} Rank: {1}", HiscoreInfo.LastManStanding.Score, HiscoreInfo.LastManStanding.Rank);
                        Output += string.Format("\nPvP Arena Score: {0} Rank: {1}", HiscoreInfo.PvPArena.Score, HiscoreInfo.PvPArena.Rank);
                        Output += string.Format("\nSoul Wars Zeal: {0} Rank: {1}", HiscoreInfo.SoulWarsZeal.Score, HiscoreInfo.SoulWarsZeal.Rank);
                        Output += string.Format("\nRifts Closed: {0} Rank: {1}", HiscoreInfo.RiftsClosed.Score, HiscoreInfo.RiftsClosed.Rank);
                        Output += string.Format("\nColosseum Glory: {0} Rank: {1}", HiscoreInfo.ColosseumGlory.Score, HiscoreInfo.ColosseumGlory.Rank);
                        Output += string.Format("\nCollections Logged: {0} Rank: {1}", HiscoreInfo.CollectionsLogged.Score, HiscoreInfo.CollectionsLogged.Rank);
                        break;
                    case "Bosses":
                        Output += string.Format("\nAbyssal Sire KC: {0} Rank: {1}", HiscoreInfo.AbyssalSire.Kills, HiscoreInfo.AbyssalSire.Rank);
                        Output += string.Format("\nAlchemical Hydra KC: {0} Rank: {1}", HiscoreInfo.AlchemicalHydra.Kills, HiscoreInfo.AlchemicalHydra.Rank);
                        Output += string.Format("\nAmoxliatl KC: {0} Rank: {1}", HiscoreInfo.Amoxliatl.Kills, HiscoreInfo.Amoxliatl.Rank);
                        Output += string.Format("\nAraxxor KC: {0} Rank: {1}", HiscoreInfo.Araxxor.Kills, HiscoreInfo.Araxxor.Rank);
                        Output += string.Format("\nArtio KC: {0} Rank: {1}", HiscoreInfo.Artio.Kills, HiscoreInfo.Artio.Rank);
                        Output += string.Format("\nBarrows Chests KC: {0} Rank: {1}", HiscoreInfo.BarrowsChests.Kills, HiscoreInfo.BarrowsChests.Rank);
                        Output += string.Format("\nBryophyta KC: {0} Rank: {1}", HiscoreInfo.Bryophyta.Kills, HiscoreInfo.Bryophyta.Rank);
                        Output += string.Format("\nCallisto KC: {0} Rank: {1}", HiscoreInfo.Callisto.Kills, HiscoreInfo.Callisto.Rank);
                        Output += string.Format("\nCalvarion KC: {0} Rank: {1}", HiscoreInfo.Calvarion.Kills, HiscoreInfo.Calvarion.Rank);
                        Output += string.Format("\nCerberus KC: {0} Rank: {1}", HiscoreInfo.Cerberus.Kills, HiscoreInfo.Cerberus.Rank);
                        Output += string.Format("\nChambers of Xeric KC: {0} Rank: {1}", HiscoreInfo.ChambersofXeric.Kills, HiscoreInfo.ChambersofXeric.Rank);
                        Output += string.Format("\nChambers of Xeric Challenge Mode KC: {0} Rank: {1}", HiscoreInfo.ChambersofXericChallengeMode.Kills, HiscoreInfo.ChambersofXericChallengeMode.Rank);
                        Output += string.Format("\nChaos Elemental KC: {0} Rank: {1}", HiscoreInfo.ChaosElemental.Kills, HiscoreInfo.ChaosElemental.Rank);
                        Output += string.Format("\nChaos Fanatic KC: {0} Rank: {1}", HiscoreInfo.ChaosFanatic.Kills, HiscoreInfo.ChaosFanatic.Rank);
                        Output += string.Format("\nCommander Zilyana KC: {0} Rank: {1}", HiscoreInfo.CommanderZilyana.Kills, HiscoreInfo.CommanderZilyana.Rank);
                        Output += string.Format("\nCorporeal Beast KC: {0} Rank: {1}", HiscoreInfo.CorporealBeast.Kills, HiscoreInfo.CorporealBeast.Rank);
                        Output += string.Format("\nCrazy Archaeologist KC: {0} Rank: {1}", HiscoreInfo.CrazyArchaeologist.Kills, HiscoreInfo.CrazyArchaeologist.Rank);
                        Output += string.Format("\nDagannoth Prime KC: {0} Rank: {1}", HiscoreInfo.DagannothPrime.Kills, HiscoreInfo.DagannothPrime.Rank);
                        Output += string.Format("\nDagannoth Rex KC: {0} Rank: {1}", HiscoreInfo.DagannothRex.Kills, HiscoreInfo.DagannothRex.Rank);
                        Output += string.Format("\nDagannoth Supreme KC: {0} Rank: {1}", HiscoreInfo.DagannothSupreme.Kills, HiscoreInfo.DagannothSupreme.Rank);
                        Output += string.Format("\nDeranged Archaeologist KC: {0} Rank: {1}", HiscoreInfo.DerangedArchaeologist.Kills, HiscoreInfo.DerangedArchaeologist.Rank);
                        Output += string.Format("\nDuke Sucellus KC: {0} Rank: {1}", HiscoreInfo.DukeSucellus.Kills, HiscoreInfo.DukeSucellus.Rank);
                        Output += string.Format("\nGeneral Graardor KC: {0} Rank: {1}", HiscoreInfo.GeneralGraardor.Kills, HiscoreInfo.GeneralGraardor.Rank);
                        Output += string.Format("\nGiant Mole KC: {0} Rank: {1}", HiscoreInfo.GiantMole.Kills, HiscoreInfo.GiantMole.Rank);
                        Output += string.Format("\nGrotesque Guardians KC: {0} Rank: {1}", HiscoreInfo.GrotesqueGuardians.Kills, HiscoreInfo.GrotesqueGuardians.Rank);
                        Output += string.Format("\nHespori KC: {0} Rank: {1}", HiscoreInfo.Hespori.Kills, HiscoreInfo.Hespori.Rank);
                        Output += string.Format("\nKalphite Queen KC: {0} Rank: {1}", HiscoreInfo.KalphiteQueen.Kills, HiscoreInfo.KalphiteQueen.Rank);
                        Output += string.Format("\nKing Black Dragon KC: {0} Rank: {1}", HiscoreInfo.KingBlackDragon.Kills, HiscoreInfo.KingBlackDragon.Rank);
                        Output += string.Format("\nKraken KC: {0} Rank: {1}", HiscoreInfo.Kraken.Kills, HiscoreInfo.Kraken.Rank);
                        Output += string.Format("\nKree'arra KC: {0} Rank: {1}", HiscoreInfo.Kreearra.Kills, HiscoreInfo.Kreearra.Rank);
                        Output += string.Format("\nK'ril Tsutsaroth KC: {0} Rank: {1}", HiscoreInfo.KrilTsutsaroth.Kills, HiscoreInfo.KrilTsutsaroth.Rank);
                        Output += string.Format("\nMoons of Peril KC: {0} Rank: {1}", HiscoreInfo.MoonsofPeril.Kills, HiscoreInfo.MoonsofPeril.Rank);
                        Output += string.Format("\nMimic KC: {0} Rank: {1}", HiscoreInfo.Mimic.Kills, HiscoreInfo.Mimic.Rank);
                        Output += string.Format("\nNex KC: {0} Rank: {1}", HiscoreInfo.Nex.Kills, HiscoreInfo.Nex.Rank);
                        Output += string.Format("\nThe Nightmare of Ashihama KC: {0} Rank: {1}", HiscoreInfo.Nightmare.Kills, HiscoreInfo.Nightmare.Rank);
                        Output += string.Format("\nPhosani's Nightmare KC: {0} Rank: {1}", HiscoreInfo.PhosanisNightmare.Kills, HiscoreInfo.PhosanisNightmare.Rank);
                        Output += string.Format("\nObor KC: {0} Rank: {1}", HiscoreInfo.Obor.Kills, HiscoreInfo.Obor.Rank);
                        Output += string.Format("\nPhantom Muspah KC: {0} Rank: {1}", HiscoreInfo.PhantomMuspah.Kills, HiscoreInfo.PhantomMuspah.Rank);
                        Output += string.Format("\nSarachnis KC: {0} Rank: {1}", HiscoreInfo.Sarachnis.Kills, HiscoreInfo.Sarachnis.Rank);
                        Output += string.Format("\nScorpia KC: {0} Rank: {1}", HiscoreInfo.Scorpia.Kills, HiscoreInfo.Scorpia.Rank);
                        Output += string.Format("\nScurrius KC: {0} Rank: {1}", HiscoreInfo.Scurrius.Kills, HiscoreInfo.Scurrius.Rank);
                        Output += string.Format("\nSkotizo KC: {0} Rank: {1}", HiscoreInfo.Skotizo.Kills, HiscoreInfo.Skotizo.Rank);
                        Output += string.Format("\nSol Heredit KC: {0} Rank: {1}", HiscoreInfo.SolHeredit.Kills, HiscoreInfo.SolHeredit.Rank);
                        Output += string.Format("\nSpindel KC: {0} Rank: {1}", HiscoreInfo.Spindel.Kills, HiscoreInfo.Spindel.Rank);
                        Output += string.Format("\nTempoross KC: {0} Rank: {1}", HiscoreInfo.Tempoross.Kills, HiscoreInfo.Tempoross.Rank);
                        Output += string.Format("\nThe Gauntlet KC: {0} Rank: {1}", HiscoreInfo.Gauntlet.Kills, HiscoreInfo.Gauntlet.Rank);
                        Output += string.Format("\nThe Corrupted Gauntlet KC: {0} Rank: {1}", HiscoreInfo.CorruptedGauntlet.Kills, HiscoreInfo.CorruptedGauntlet.Rank);
                        Output += string.Format("\nThe Hueycoatl KC: {0} Rank: {1}", HiscoreInfo.Hueycoatl.Kills, HiscoreInfo.Hueycoatl.Rank);
                        Output += string.Format("\nLeviathan KC: {0} Rank: {1}", HiscoreInfo.Leviathan.Kills, HiscoreInfo.Leviathan.Rank);
                        Output += string.Format("\nRoyal Titans KC: {0} Rank: {1}", HiscoreInfo.RoyalTitans.Kills, HiscoreInfo.RoyalTitans.Rank);
                        Output += string.Format("\nThe Whisperer KC: {0} Rank: {1}", HiscoreInfo.Whisperer.Kills, HiscoreInfo.Whisperer.Rank);
                        Output += string.Format("\nTheatre of Blood KC: {0} Rank: {1}", HiscoreInfo.TheatreofBlood.Kills, HiscoreInfo.TheatreofBlood.Rank);
                        Output += string.Format("\nTheatre of Blood Hard Mode KC: {0} Rank: {1}", HiscoreInfo.TheatreofBloodHardMode.Kills, HiscoreInfo.TheatreofBloodHardMode.Rank);
                        Output += string.Format("\nThermonuclear Smoke Devil KC: {0} Rank: {1}", HiscoreInfo.ThermonuclearSmokeDevil.Kills, HiscoreInfo.ThermonuclearSmokeDevil.Rank);
                        Output += string.Format("\nTombs of Amascut KC: {0} Rank: {1}", HiscoreInfo.TombsOfAmascut.Kills, HiscoreInfo.TombsOfAmascut.Rank);
                        Output += string.Format("\nTombs of Amascut Expert Mode KC: {0} Rank: {1}", HiscoreInfo.TombsOfAmascutExpertMode.Kills, HiscoreInfo.TombsOfAmascutExpertMode.Rank);
                        Output += string.Format("\nTzKal-Zuk KC: {0} Rank: {1}", HiscoreInfo.Zuk.Kills, HiscoreInfo.Zuk.Rank);
                        Output += string.Format("\nTzTok-Jad KC: {0} Rank: {1}", HiscoreInfo.Jad.Kills, HiscoreInfo.Jad.Rank);
                        Output += string.Format("\nVardorvis KC: {0} Rank: {1}", HiscoreInfo.Vardorvis.Kills, HiscoreInfo.Vardorvis.Rank);
                        Output += string.Format("\nVenenatis KC: {0} Rank: {1}", HiscoreInfo.Venenatis.Kills, HiscoreInfo.Venenatis.Rank);
                        Output += string.Format("\nVetion KC: {0} Rank: {1}", HiscoreInfo.Vetion.Kills, HiscoreInfo.Vetion.Rank);
                        Output += string.Format("\nVorkath KC: {0} Rank: {1}", HiscoreInfo.Vorkath.Kills, HiscoreInfo.Vorkath.Rank);
                        Output += string.Format("\nWintertodt KC: {0} Rank: {1}", HiscoreInfo.Wintertodt.Kills, HiscoreInfo.Wintertodt.Rank);
                        Output += string.Format("\nYama KC: {0} Rank: {1}", HiscoreInfo.Yama.Kills, HiscoreInfo.Yama.Rank);
                        Output += string.Format("\nZalcano KC: {0} Rank: {1}", HiscoreInfo.Zalcano.Kills, HiscoreInfo.Zalcano.Rank);
                        Output += string.Format("\nZulrah KC: {0} Rank: {1}", HiscoreInfo.Zulrah.Kills, HiscoreInfo.Zulrah.Rank);
                        break;
                    default:
                        return string.Empty;
                }
                return Output;
            }
        }

        public ICommand LookupPlayer
        {
            get { return _lookupPlayer; }
            set { SetProperty(ref _lookupPlayer, value, nameof(LookupPlayer)); }
        }

        public PlayerInfo HiscoreInfo
        {
            get { return _hiscoreInfo; }
            set { SetProperty(ref _hiscoreInfo, value, nameof(HiscoreInfo)); OnPropertyChanged(nameof(DisplayOutput)); }
        }
    }
}
