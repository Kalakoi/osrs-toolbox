using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public class RandomIntegerRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string jsonrpc { get; set; } = "2.0";
        [JsonPropertyName("method")]
        public string method { get; set; } = "generateIntegers";
        [JsonPropertyName("params")]
        public RandomIntegerRequestParameters parameters { get; set; } = new();
        public long id { get; set; } = DateTime.Now.Ticks;

        public string GetJson()
        {
            return JsonSerializer.Serialize<RandomIntegerRequest>(this);
        }
    }

    public class RandomIntegerRequestParameters
    {
        public string apiKey { get; set; }
        public int n { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public bool replacement { get; set; }
    }

    public class RandomIntegerRequestResponse
    {
        public string jsonrpc { get; set; }
        public RandomIntegerResult result { get; set; }
        public long id { get; set; }
    }

    public class RandomIntegerResult
    {
        public RandomIntegerData random { get; set; }
        public int bitsUsed { get; set; }
        public int bitsLeft { get; set; }
        public int requestsLeft { get; set; }
        public int advisoryDelay { get; set; }
    }

    public class RandomIntegerData
    {
        public int[] data { get; set; }
        public string completionTime { get; set; }
    }
}
