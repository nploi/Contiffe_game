using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{
    public class Utils
    {
       static public Dictionary<string, object> GetMapFromData(object data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
        }
    }
}
