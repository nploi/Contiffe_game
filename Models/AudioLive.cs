using Newtonsoft.Json;
using System;
using System.Linq;

namespace Models
{
    public class AudioLive
    {
        public int BytesRecorded { set; get; }
        public byte[] Buffer { set; get; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public AudioLive FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<AudioLive>(json);
            }
            return null;
        }
    }
}
