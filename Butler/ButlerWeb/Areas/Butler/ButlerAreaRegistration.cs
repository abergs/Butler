using System.Web.Mvc;

namespace ButlerWeb.Areas.Butler
{
    public class ButlerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Butler";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Butler_default",
                "Butler/{controller}/{action}/{id}",
                new { controller = "Welcome", action = "Index", id = UrlParameter.Optional },
                new[] { "ButlerWeb.Areas.Butler.Controllers" }
            );
        }
    }
}
