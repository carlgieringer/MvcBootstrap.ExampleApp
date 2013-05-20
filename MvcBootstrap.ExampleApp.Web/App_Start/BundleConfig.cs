namespace MvcBootstrap.ExampleApp.Web.App_Start
{
    using System.Linq;
    using System.Web.Optimization;

    using MvcBootstrap.ExampleApp.Web.App_Start.Bundles;

    /// <summary>
    /// Responsible for registering script and style bundles with MVC.
    /// </summary>
    /// <remarks>
    /// There are three steps to adding a new bundle: 1) create a new static BundleInfo 
    /// in App_Start.Bundles.Bundles.  This instance contains all the information about
    /// your bundle.  2) Add the BundleInfo instance to <see cref="BundleConfig.StyleInfos"/>
    /// or <see cref="BundleConfig.ScriptInfos"/>, as appropriate.  On application start
    /// these bundles will be registered with ASP.NET MVC, and so be available from within views.
    /// 3) Render the bundle in your views using the appropriate Razor helper.  You refer to the
    /// bundle by its <see cref="BundleInfo.Name"/> to keep your code DRY and statically checked.
    /// </remarks>
    public static class BundleConfig
    {
        public static readonly BundleInfo[] StyleInfos = new[]
            {
                Bundles.Bundles.Styles.Bootstrap,
                Bundles.Bundles.Styles.Site,
                Bundles.Bundles.Styles.Mvc,
                Bundles.Bundles.Styles.Chosen,
            };

        public static readonly BundleInfo[] ScriptInfos = new[]
            {
                Bundles.Bundles.Scripts.Bootstrap,
                Bundles.Bundles.Scripts.Modernizr,
                Bundles.Bundles.Scripts.RespondJs,
                Bundles.Bundles.Scripts.Chosen,
            };

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            foreach (var info in StyleInfos)
            {
                bundles.Add(new StyleBundle(info.Name).Include(info.Files.ToArray()));
            }

            foreach (var info in ScriptInfos)
            {
                bundles.Add(new ScriptBundle(info.Name).Include(info.Files.ToArray()));
            }
        }
    }
}