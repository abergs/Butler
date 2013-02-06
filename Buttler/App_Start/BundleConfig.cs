using System.Web;
using System.Web.Optimization;

namespace Buttler.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("ButtlerWithStyle").Include(
                "~/Content/themes/base/main.css"));
        }
    }
}