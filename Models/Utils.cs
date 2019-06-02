using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
