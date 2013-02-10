using System.Web.Mvc;
using System.Web.Optimization;

namespace Buttler.Areas.Buttler
{
    public class ButtlerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Buttler";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Buttler_default",
                "Buttler/{controller}/{action}/{id}",
                new {controller= "Pages", action = "Index", id = UrlParameter.Optional }
            );

            var bundles = BundleTable.Bundles;

            bundles.Add(new StyleBundle("~/ButtlerStyle").Include(
                       "~/Areas/Buttler/Content/themes/base/bootstrap.css",

                       "~/Areas/Buttler/Content/themes/base/bootstrap-responsive.css",
                       "~/Areas/Buttler/Content/themes/base/main.css"));
        }
    }
}
