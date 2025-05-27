using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WikiClientLibrary;
using WikiClientLibrary.Client;
using WikiClientLibrary.Sites;
using WikiClientLibrary.Pages;
using WikiClientLibrary.Pages.Queries;
using WikiClientLibrary.Pages.Queries.Properties;
using WikiClientLibrary.Generators;

namespace osrs_toolbox
{
    public static class Wiki
    {
        private static string BaseSite = @"oldschool.runescape.wiki";
        private static string BaseEndpoint = @"https://oldschool.runescape.wiki/api.php";
        private static string BaseEndpointOptions = @"?format=json&formatversion=2";
        private static string ListMonstersEndpoint = @"&action=query&list=categorymembers&cmtitle=Category:Monsters";
        private static string UserAgent = @"osrs-toolbox";

        public static async Task<string> TestAsync()
        {
            WikiClient client = new WikiClient();
            client.ClientUserAgent = UserAgent;
            WikiSite site = new WikiSite(client, await WikiSite.SearchApiEndpointAsync(client, BaseEndpoint).ConfigureAwait(false));
            await site.Initialization.ConfigureAwait(false);

            CategoriesGenerator cg = new CategoriesGenerator(site);

            //CategoryMembersGenerator generator = new CategoryMembersGenerator(site);
            //generator.CategoryTitle = "Monsters";
            //List<WikiPage> pages = await generator.EnumPagesAsync().Take(10).ToListAsync().ConfigureAwait(false);

            List<WikiPageCategoryInfo> pages = await cg.EnumItemsAsync().Take(10).ToListAsync().ConfigureAwait(false);
            string output = string.Empty;
            foreach (WikiPageCategoryInfo page in pages)
            {
                output += page.Title + "\n";
            }
            return output;
        }
    }
}
