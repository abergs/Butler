using System.Web;
using System.Web.Mvc;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class UninstalledAttribute : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Look for existing users

            //Butler.Store.GetNullable<Web.Models.


        }
    }
}