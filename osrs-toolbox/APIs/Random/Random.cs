using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace osrs_toolbox
{
    public static class Random
    {
        private static string BaseEndpoint = @"https://api.random.org/json-rpc/4/invoke";
        private static string APIKey = APIKeys.RANDOM;

        public static async Task<int[]> GetRandomIntegersAsync(int Minimum, int Maximum, int Count, bool AllowDuplicates)
        {
            RandomIntegerRequest Request = new RandomIntegerRequest()
            {
                parameters = new()
                {
                    apiKey = APIKey,
                    n = Count,
                    min = Minimum,
                    max = Maximum,
                    replacement = AllowDuplicates
                }
            };
            string TestString = string.Empty;
            TestString += string.Format("{0}: {1}\n", nameof(Request.jsonrpc), Request.jsonrpc);
            TestString += string.Format("{0}: {1}\n", nameof(Request.method), Request.method);
            string RequestJson = Request.GetJson();
            TestString += string.Format("{0}\n", RequestJson);
            string ResponseJson = await RestServices.GetPostResponseAsync(new Uri(BaseEndpoint), RequestJson, APIKey).ConfigureAwait(false);
            TestString += string.Format("{0}", ResponseJson);
            MessageBox.Show(TestString);
            RandomIntegerRequestResponse response = JsonSerializer.Deserialize<RandomIntegerRequestResponse>(ResponseJson);
            return response.result.random.data;
            //return TestString;
            //return ResponseJson;
        }
    }
}
