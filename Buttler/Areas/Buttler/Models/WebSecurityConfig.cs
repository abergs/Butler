using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace Buttler.Areas.Buttler.Models
{
     public class WebSecurityConfig
    {
        static bool initiated = false;
        public static void InitializeDatabaseConnection()
        {
            if (!initiated)
            {
                initiated = true;
                WebSecurity.InitializeDatabaseConnection("ButtlerContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);                
            }
        }

    }
}
