namespace MvcBootstrap.ExampleApp.Web.App_Start.Bundles
{
    using System.Diagnostics.CodeAnalysis;

    public static class Bundles
    {
        public static class Styles
        {
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural initialization.")]
            public static readonly BundleInfo Site = new BundleInfo(
                "~/css/site",
                new[]
                {
                    "~/Static/css/mvc-bootstrap.css",
                    "~/Static/css/styles.css",
                });

            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural initialization.")]
            public static readonly BundleInfo Bootstrap = new BundleInfo(
                "~/css/bootstrap",
                new[]
                {
                    "~/Static/css/vendor/bootstrap/css/bootstrap.css",
                    "~/Static/css/bootstrap-between.css",
                    "~/Static/css/vendor/bootstrap/css/bootstrap-responsive.css"
                });
        }

        public static class Scripts
        {
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structural Initialization.")]
            public static readonly BundleInfo Bootstrap = new BundleInfo(
                "~/js/bootstrap", 
                new[]
                {
                    "~/Static/js/vendor/bootstrap.js"
                });

            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structurual initialization.")]
            public static readonly BundleInfo Modernizr = new BundleInfo(
                "~/js/modernizr", 
                new[]
                {
                     "~/Static/js/vendor/modernizr-2.6.2.js"
                });

            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Structurual initialization.")]
            public static readonly BundleInfo RespondJs = new BundleInfo(
                "~/js/respond.js",
                new[]
                {
                     "~/Static/js/vendor/respond.js"
                });
        }
    }
}