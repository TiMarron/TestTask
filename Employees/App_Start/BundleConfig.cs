using System.Web;
using System.Web.Optimization;

namespace Employees
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/Employees/autocomplite").Include(
                "~/Scripts/Employees/Autocomplite.js"));
        }
    }
}