using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class PlayerInfoService
    {
        private readonly HttpClient _httpClient;
        private bool _throwMismatchException;

        internal bool ThrowMismatchException
        {
            get => _throwMismatchException;
            set => _throwMismatchException = value;
        }

        public PlayerInfoService(HttpClient httpClient, bool throwMismatchException = true)
        {
            _httpClient = httpClient;
            _throwMismatchException = throwMismatchException;
        }

        public async Task<PlayerInfo> GetPlayerInfoAsync(string userName)
        {
            bool playerFound = false;
            var playerInfo = new PlayerInfo { Name = userName };

            //HttpResponseMessage response = null;
            HttpResponseMessage response = await _httpClient.GetAsync("https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + userName).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                playerInfo.Status = PlayerInfoStatus.NotFound;
                return playerInfo;
            }

            PlayerInfo mainPlayerInfo = new PlayerInfo { Name = userName };
            PlayerInfo ironPlayerInfo = new PlayerInfo { Name = userName };
            PlayerInfo hcimPlayerInfo = new PlayerInfo { Name = userName };
            PlayerInfo uimPlayerInfo = new PlayerInfo { Name = userName };

            return await ParseHttpResponse(playerInfo, response).ConfigureAwait(false);

            HttpResponseMessage mainResponse = await _httpClient.GetAsync("https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + userName).ConfigureAwait(false);
            HttpResponseMessage ironResponse = await _httpClient.GetAsync("https://secure.runescape.com/m=hiscore_oldschool_ironman/index_lite.ws?player=" + userName).ConfigureAwait(false);
            HttpResponseMessage hcimResponse = await _httpClient.GetAsync("https://secure.runescape.com/m=hiscore_oldschool_hardcore_ironman/index_lite.ws?player=" + userName).ConfigureAwait(false);
            HttpResponseMessage uimResponse = await _httpClient.GetAsync("https://secure.runescape.com/m=hiscore_oldschool_ultimate/index_lite.ws?player=" + userName).ConfigureAwait(false);

            if (mainResponse.StatusCode != HttpStatusCode.NotFound)
            {
                playerFound = true;
                mainPlayerInfo = await ParseHttpResponse(mainPlayerInfo, mainResponse).ConfigureAwait(false);
            }
            if (ironResponse.StatusCode != HttpStatusCode.NotFound)
            {
                playerFound = true;
                ironPlayerInfo = await ParseHttpResponse(ironPlayerInfo, ironResponse).ConfigureAwait(false);
            }
            if (hcimResponse.StatusCode != HttpStatusCode.NotFound)
            {
                playerFound = true;
                hcimPlayerInfo = await ParseHttpResponse(hcimPlayerInfo, hcimResponse).ConfigureAwait(false);
            }
            if (uimResponse.StatusCode != HttpStatusCode.NotFound)
            {
                playerFound = true;
                uimPlayerInfo = await ParseHttpResponse(uimPlayerInfo, uimResponse).ConfigureAwait(false);
            }

            if (!playerFound)
            {
                playerInfo.Status = PlayerInfoStatus.NotFound;
                return playerInfo;
            }
            else
            {

            }
        }

        public async Task<IEnumerable<PlayerInfo>> GetPlayerInfoAsync(string[] userNames)
        {
            var tasks = userNames.Select(x => GetPlayerInfoAsync(x));
            return await Task.WhenAll(tasks)
                .ConfigureAwait(false);
        }

        private async Task<PlayerInfo> ParseHttpResponse(PlayerInfo playerInfo, HttpResponseMessage response)
        {
            var stream = await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false);

            using var reader = new StreamReader(stream);

            var properties = typeof(PlayerInfo).GetProperties()
                .Where(x => typeof(IPlayerInfoProperty).IsAssignableFrom(x.PropertyType)).ToArray();

            if (properties.Count() != TotalLines(reader) && _throwMismatchException)
                throw new FormatException("Property mismatch; OSRS API Contains more properties than PlayerInfo class. Please contact Repository creator");

            foreach (PropertyInfo info in properties)
            {
                string[] values = reader.ReadLine().Split(',');
                var property = ParseLine(values, info);

                info.SetValue(playerInfo, property);
            }

            playerInfo.Status = PlayerInfoStatus.Success;

            return playerInfo;
        }

        private int TotalLines(StreamReader reader)
        {
            int i = 0;
            while (reader.ReadLine() != null) i++;

            reader.BaseStream.Position = 0;

            return i;
        }

        private IPlayerInfoProperty ParseLine(string[] data, PropertyInfo info)
        {
            if (info.PropertyType == typeof(Skill))
            {
                return new Skill
                {
                    Name = info.Name,
                    Rank = int.Parse(data[0]),
                    Level = int.Parse(data[1]),
                    Experience = int.Parse(data[2])
                };
            }

            if (info.PropertyType == typeof(Activity))
            {
                return new Activity
                {
                    Name = info.Name,
                    Rank = int.Parse(data[0]),
                    Score = int.Parse(data[1])
                };
            }

            if (info.PropertyType == typeof(Boss))
            {
                return new Boss
                {
                    Name = info.Name,
                    Rank = int.Parse(data[0]),
                    Kills = int.Parse(data[1])
                };
            }

            throw new NotImplementedException($"Unimplemented type {info.PropertyType}");
        }
    }
}
