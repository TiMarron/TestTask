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

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-select.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-select.min.css",
                "~/Content/site.css"));
        }
    }
}