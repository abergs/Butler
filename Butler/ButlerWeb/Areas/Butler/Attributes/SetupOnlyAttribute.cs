using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ButlerWeb.Areas.Butler.Controllers
{
    public class SetupOnlyAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Do whatever checking you need here
            var auth = new Models.Authorization();

            if (auth.Users.Count > 0)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
