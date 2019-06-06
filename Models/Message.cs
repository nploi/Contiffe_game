using Newtonsoft.Json;
using System;
using System.Linq;

namespace Models
{
    public class MyMessage
    {
        public string Content { set; get; }
        public string UserName { set; get; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public MyMessage FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<MyMessage>(json);
            }
            return null;
        }
    }
}
