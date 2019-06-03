using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Newtonsoft.Json;

namespace Models
{

    public class Question
    {
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public List<Answer> ListAnswers = new List<Answer>();
        public string CorrectAnswerId { get; set; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public Question FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<Question>(json);
            }
            return null;
        }
    }
}
