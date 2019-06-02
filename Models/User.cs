using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public String Name { set; get; }
        public String Type { set; get; }
        public User() { }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public Question FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                Question deserializedQuestion = JsonConvert.DeserializeObject<Question>(json);
                return deserializedQuestion;
            }
            return null;
        }
    }
}
