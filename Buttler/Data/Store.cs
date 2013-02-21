using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler
{
    public class Store
    {
        public static T Get<T> (string ID) where T : new(){
            try
            {
                var raw = FileStore.Read(HttpContext.Current.Server.MapPath("~/App_Data/Buttler/" + ID + ".json"));
                return (T)JsonSerializer.Parse<T>(raw);
            }
            catch (Exception)
            {
                return new T();
            }            
        }

        public static T GetNullable<T>(string ID) {
            try
            {
                var raw = FileStore.Read(HttpContext.Current.Server.MapPath("~/App_Data/Buttler/" + ID + ".json"));
                return (T)JsonSerializer.Parse<T>(raw);
            }
            catch (Exception)
            {
                return default(T);
            }     
        }

        public static void Save(dynamic model){
            var raw = JsonSerializer.Serialize(model);
            FileStore.Save(HttpContext.Current.Server.MapPath("~/App_Data/Buttler/" + model.ID + ".json"),raw);
        }
    }
}