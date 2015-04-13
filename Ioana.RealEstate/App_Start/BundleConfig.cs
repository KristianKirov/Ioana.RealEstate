using System.Web;
using System.Web.Optimization;

namespace Ioana.RealEstate
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/chosen.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-filestyle").Include(
                      "~/Scripts/bootstrap-filestyle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/upsert-estate").Include(
                      "~/Scripts/upsert-estate.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/chosen.min.css",
                      "~/Content/chosen-bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/account-css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/account.css"));
        }
    }
}
