using System.Web;
using System.Web.Optimization;

namespace Buttler
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/ButtlerStyle").Include(
                "~/Content/themes/base/bootstrap.css",

                "~/Content/themes/base/bootstrap-responsive.css",
                "~/Content/themes/base/main.css"));
        }
    }
}