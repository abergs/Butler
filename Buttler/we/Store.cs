using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler
{
    public class Store
    {
        public static T Get<T> (string ID) {

            var raw = FileStore.Read(HttpContext.Current.Server.MapPath("~/App_Data/Buttler/" + ID + ".data"));
            var model = (T) JsonSerializer.Parse<T>(raw);
            return model;
        }

        public static void Save(dynamic model){
            var raw = JsonSerializer.Serialize(model);
            FileStore.Save(HttpContext.Current.Server.MapPath("~/App_Data/Buttler/" + model.ID + ".data"),raw);
        }
    }
}