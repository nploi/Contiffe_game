using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImageLive
    {
        public byte[] Img1D { set; get; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        static public ImageLive FromJson(String json)
        {
            if (json != null && json.Trim().Count() >= 0)
            {
                return JsonConvert.DeserializeObject<ImageLive>(json);
            }
            return null;
        }
    }
}
