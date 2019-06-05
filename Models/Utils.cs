using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Utils
    {
        static public Dictionary<string, object> GetMapFromData(object data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
