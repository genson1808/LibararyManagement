using System.Web;
using System.Web.Optimization;

namespace LibraryManegement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                       "~/Scripts/vendor/js/bootstrap.min.js",
                       "~/Scripts/js/sb-admin-2.js",
                       "~/Scripts/awesome/all.min.js",
                        "~/Scripts/vendor/jquery/jquery.min.js",
                         "~/Scripts/vendor/jquery-easing/jquery-easing.min.js",
                         "~/Scripts/vendor/chart.js/Chart.min.js",
                         "~/Scripts/js/demo/chart-area-demo.js",
                         "~/Scripts/js/demo/chart-pie-demo.js"));

            bundles.Add(new StyleBundle("~/Content/index").Include(
                     "~/Content/vendor/fontawesome-free/css/all.min.css", "~/Content/css/sb-admin-2.min.css"));

            bundles.Add(new StyleBundle("~/Content/member").Include(
                     "~/Content/member.css"));
        }
    }
}
