namespace MvcBootstrap.ExampleApp.Web.Tests.BundleTests
{
    using System.Web.Optimization;

    using MvcBootstrap.ExampleApp.Web.App_Start;
    using MvcBootstrap.ExampleApp.Web.App_Start.Bundles;

    using NUnit.Framework;

    [TestFixture]
    internal class ScriptsFixture : FixtureBase
    {
        [Test]
        public void TheBootstrapScriptBundleIsRegistered()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundle = BundleTable.Bundles.GetBundleFor(Bundles.Scripts.Bootstrap.Name);

            Assert.That(bundle, Is.Not.Null);
        }

        [Test]
        public void TheModernizrScriptBundleIsRegistered()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundle = BundleTable.Bundles.GetBundleFor(Bundles.Scripts.Modernizr.Name);

            Assert.That(bundle, Is.Not.Null);
        }

        [Test]
        public void TheRespondJsScriptBundleIsRegistered()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundle = BundleTable.Bundles.GetBundleFor(Bundles.Scripts.RespondJs.Name);

            Assert.That(bundle, Is.Not.Null);
        }
    }
}
