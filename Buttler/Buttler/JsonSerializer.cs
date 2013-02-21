using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler
{
    public class JsonSerializer
    {
        public static string Serialize(dynamic model) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        public static T Parse<T>(string json) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}