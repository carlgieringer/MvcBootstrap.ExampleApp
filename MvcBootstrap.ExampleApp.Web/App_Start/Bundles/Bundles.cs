namespace MvcBootstrap.ExampleApp.Web.App_Start.Bundles
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural initialization.")]
    public static class StyleBundles
    {
        public static readonly BundleInfo Bootstrap = new BundleInfo(
            "~/css/bootstrap",
            new[]
                {
                    "~/Static/css/vendor/bootstrap/css/bootstrap.css",
                    "~/Static/css/bootstrap-between.css",
                    "~/Static/css/vendor/bootstrap/css/bootstrap-responsive.css"
                });

        public static readonly BundleInfo Chosen = new BundleInfo(
            "~/css/chosen",
            new[]
                    {
                        "~/Static/css/vendor/chosen/chosen.css"
                    });

        public static readonly BundleInfo JQueryUI = new BundleInfo(
            "~/css/jquery-ui",
            new[]
                    {
                        "~/Static/css/vendor/jquery-ui/themes/base/jquery.ui.*"
                    });

        public static readonly BundleInfo Mvc = new BundleInfo(
            "~/css/mvc",
            new[]
                {
                    "~/Static/css/asp.net-mvc.css",
                });

        public static readonly BundleInfo MvcBootstrap = new BundleInfo(
            "~/css/mvc-bootstrap",
            new[]
                {
                    "~/Static/css/mvc-bootstrap.css",
                    "~/Static/css/mvc-bootstrap-example-app.css",
                });
    }

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural initialization.")]
    public static class ScriptBundles
    {
        public static readonly BundleInfo Bootstrap = new BundleInfo(
            "~/js/bootstrap",
            new[]
                {
                    "~/Static/js/vendor/bootstrap.js"
                });

        public static readonly BundleInfo Chosen = new BundleInfo(
            "~/js/chosen",
            new[]
                {
                     "~/Static/js/vendor/chosen.jquery.js"
                });

        public static readonly BundleInfo JQuery = new BundleInfo(
            "~/js/jquery",
            new[]
                {
                     "~/Static/js/vendor/jquery-1.*"
                });

        public static readonly BundleInfo JQueryUI = new BundleInfo(
            "~/js/jquery-ui",
            new[]
                {
                     "~/Static/js/vendor/jquery-ui-1.10.3.js"
                });

        public static readonly BundleInfo JQueryAjax = new BundleInfo(
            "~/js/jquery-ui",
            new[]
                {
                     "~/Static/js/vendor/jquery.unobtrusive-ajax.js"
                });

        public static readonly BundleInfo JQueryValidate = new BundleInfo(
            "~/js/jquery-ui",
            new[]
                {
                     "~/Static/js/vendor/jquery.validate.js",
                     "~/Static/js/vendor/jquery.validate.unobtrusive.js"
                });

        public static readonly BundleInfo Modernizr = new BundleInfo(
            "~/js/modernizr",
            new[]
                {
                     "~/Static/js/vendor/modernizr-2.6.2.js"
                });

        public static readonly BundleInfo RespondJs = new BundleInfo(
            "~/js/respond.js",
            new[]
                {
                     "~/Static/js/vendor/respond.js"
                });
    }
}