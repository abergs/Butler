using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ButlerWeb.Areas.Butler.Helpers
{
    public class Attributes
    {
        public static string GetName(Type type)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);  // Reflection
            foreach (System.Attribute attr in attrs)
            {
                if (attr is DisplayNameAttribute)
                {
                    DisplayNameAttribute a = (DisplayNameAttribute)attr;
                    return a.DisplayName;
                }
            }

            return type.Name;
        }
    }
}