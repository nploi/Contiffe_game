using Newtonsoft.Json;
using System;
using System.Linq;

namespace Models
{
    public class Game
    {
        public int Award { set; get; }
        public User User { set; get; }

        public Game ()
        {
            this.User = new User();
            this.Award = 0;
        }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public Game FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<Game>(json);
            }
            return null;
        }
    }
}
