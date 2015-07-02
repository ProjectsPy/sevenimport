using System.Web;
using System.Web.Optimization;

namespace sevenimport
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/bootstrap.css",
                "~/css/owlcarousel.css",
                "~/css/owltheme.css",
                "~/css/globalstyleorange.css",
                "~/css/style.css",
                "~/css/layerslider.css"
                ));

            bundles.Add(new StyleBundle("~/font").Include(
                "~/fontawesome/css/fontawesome.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ui").Include(
                      "~/js/jquery1.js",
                      "~/js/app.js",
                      "~/js/owlcarousel.js",
                      "~/js/jquerystellar.js",
                      "~/js/greensock.js",
                      "~/js/layerslidertransitions.js",
                      "~/js/layersliderkreaturamedia.js"));
        }
    }
}
