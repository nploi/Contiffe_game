using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Answer
    {
        public string Id { get; set; }
        public string Content{get;set;}
        public Answer()
        {
            Id = "";
        }
        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public Answer FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<Answer>(json);
            }
            return null;
        }
    }
}
