namespace MvcBootstrap.ExampleApp.Web.App_Start
{
    using System.Linq;
    using System.Web.Optimization;

    using MvcBootstrap.ExampleApp.Web.App_Start.Bundles;

    public class BundleConfig
    {
        public static readonly BundleInfo[] StyleInfos = new[]
            {
                Bundles.Bundles.Styles.Bootstrap,
                Bundles.Bundles.Styles.Site,
            };

        public static readonly BundleInfo[] ScriptInfos = new[]
            {
                Bundles.Bundles.Scripts.Bootstrap,
                Bundles.Bundles.Scripts.Modernizr,
                Bundles.Bundles.Scripts.RespondJs
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