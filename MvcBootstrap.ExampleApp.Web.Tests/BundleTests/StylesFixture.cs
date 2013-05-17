namespace MvcBootstrap.ExampleApp.Web.Tests.BundleTests
{
    using System.Web.Optimization;

    using MvcBootstrap.ExampleApp.Web.App_Start;
    using MvcBootstrap.ExampleApp.Web.App_Start.Bundles;

    using NUnit.Framework;

    [TestFixture]
    internal class StylesFixture : FixtureBase
    {
        [Test]
        public void TheSiteStyleBundleIsRegistered()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundle = BundleTable.Bundles.GetBundleFor(Bundles.Styles.Site.Name);

            Assert.That(bundle, Is.Not.Null);
        }

        [Test]
        public void TheBootstrapStyleBundleIsRegistered()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundle = BundleTable.Bundles.GetBundleFor(Bundles.Styles.Bootstrap.Name);

            Assert.That(bundle, Is.Not.Null);
        }
    }
}
