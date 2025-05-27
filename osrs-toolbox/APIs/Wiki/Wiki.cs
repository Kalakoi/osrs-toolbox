using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public static class Wiki
    {
        private static string BaseEndpoint = @"https://oldschool.runescape.wiki/api.php?format=json&formatversion=2";
        private static string ListMonstersEndpoint = @"&action=query&list=categorymembers&cmtitle=Category:Monsters";
    }
}
