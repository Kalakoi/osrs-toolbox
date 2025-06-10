using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osrs_toolbox
{
    public static class Random
    {
        private static string BaseEndpoint = @"https://api.randdom.org/json-rpc/4/invoke";
        private static string APIKey = APIKeys.RANDOM;
    }
}
