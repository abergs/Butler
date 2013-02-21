using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butler
{
    public class Store
    {
        private static readonly string path = "~/App_Data/Butler";
        private static readonly string fileExtension = ".json";

        public static T Get<T>(string ID) where T : new()
        {
            try
            {
                return GetModel<T>(ID);
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public static T GetNullable<T>(string ID)
        {
            try
            {
                return GetModel<T>(ID);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        private static T GetModel<T>(string ID)
        {
            var p = getPath<T>(ID);
            var raw = FileStore.Read(HttpContext.Current.Server.MapPath(p));
            return (T)JsonSerializer.Parse<T>(raw);
        }

        public static void Save<T>(T model)
        {
            dynamic dynamicmodel = model;
            var p = getPath<T>(dynamicmodel.ID);

            var raw = JsonSerializer.Serialize(model);
            FileStore.Save(HttpContext.Current.Server.MapPath(p), raw);
        }

        private static string getPath<T>(string ID)
        {
            Type myType = typeof(T);
            string p = string.Format("{0}/{1}/{2}{3}", path, myType.Name, ID, fileExtension);

            return p;
        }
    }
}