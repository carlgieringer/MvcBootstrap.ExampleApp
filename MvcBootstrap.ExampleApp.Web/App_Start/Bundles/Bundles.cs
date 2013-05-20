namespace MvcBootstrap.ExampleApp.Web.App_Start.Bundles
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural initialization.")]
    public static class Bundles
    {
        public static class Styles
        {
            public static readonly BundleInfo Site = new BundleInfo(
                "~/css/site",
                new[]
                {
                    "~/Static/css/mvc-bootstrap.css",
                    "~/Static/css/styles.css",
                });

            public static readonly BundleInfo Mvc = new BundleInfo(
                "~/css/mvc",
                new[]
                {
                    "~/Static/css/asp.net-mvc.css",
                });

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
        }

        public static class Scripts
        {
            public static readonly BundleInfo Bootstrap = new BundleInfo(
                "~/js/bootstrap", 
                new[]
                {
                    "~/Static/js/vendor/bootstrap.js"
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

            public static readonly BundleInfo Chosen = new BundleInfo(
                "~/js/chosen",
                new[]
                {
                     "~/Static/js/vendor/chosen.jquery.js"
                });
        }
    }
}