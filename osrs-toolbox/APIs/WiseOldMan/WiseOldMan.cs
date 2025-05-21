using System.Text.Json;
using System.Windows.Media.Imaging;

namespace osrs_toolbox
{
    public static class WiseOldMan
    {
        private static string CompetitionEndpoint = @"https://api.wiseoldman.net/v2/competitions/";
        private static string GroupEndpoint = @"https://api.wiseoldman.net/v2/groups/";
        private static string PlayerEndpoint = @"https://api.wiseoldman.net/v2/players/";

        public static Player GetPlayer(string Username)
        {
            string res = RestServices.GetResponse(new Uri(PlayerEndpoint + Username), string.Empty);
            Player p = JsonSerializer.Deserialize<Player>(res);
            return p;
        }

        public static async Task<Player> GetPlayerAsync(string Username)
        {
            string res = await RestServices.GetResponseAsync(new Uri(PlayerEndpoint + Username), string.Empty).ConfigureAwait(false);
            Player p = JsonSerializer.Deserialize<Player>(res);
            return p;
        }

        public static Group GetGroup(int ID)
        {
            string res = RestServices.GetResponse(new Uri(GroupEndpoint + ID.ToString()), string.Empty);
            Group g = JsonSerializer.Deserialize<Group>(res);
            return g;
        }

        public static async Task<Group> GetGroupAsync(int ID)
        {
            string res = await RestServices.GetResponseAsync(new Uri(GroupEndpoint + ID.ToString()), string.Empty).ConfigureAwait(false);
            Group g = JsonSerializer.Deserialize<Group>(res);
            return g;
        }

        public static Competition GetCompetition(int ID)
        {
            string res = RestServices.GetResponse(new Uri(CompetitionEndpoint + ID.ToString()), string.Empty);
            Competition c = JsonSerializer.Deserialize<Competition>(res);
            return c;
        }

        public static async Task<Competition> GetCompetitionAsync(int ID)
        {
            string res = await RestServices.GetResponseAsync(new Uri(CompetitionEndpoint + ID.ToString()), string.Empty).ConfigureAwait(false);
            Competition c = JsonSerializer.Deserialize<Competition>(res);
            return c;
        }
    }
}