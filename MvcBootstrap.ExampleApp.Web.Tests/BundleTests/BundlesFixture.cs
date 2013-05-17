namespace MvcBootstrap.ExampleApp.Web.Tests.BundleTests
{
    using System.IO;
    using System.Linq;
    using System.Web.Optimization;

    using MvcBootstrap.ExampleApp.Web.App_Start;

    using NUnit.Framework;

    [TestFixture]
    internal class BundlesFixture : FixtureBase
    {
        [Test]
        public void AllBundlesHaveAtLeastOneFileIncluded()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var emptyBundles = BundleTable.Bundles
                .Where(bundle => !bundle.EnumerateFiles(this.BundleContext).Any())
                .Select(bundle => bundle.Path)
                .ToArray();

            Assert.That(emptyBundles, Is.Empty, string.Format("The following bundles are empty: {0}", string.Join(", ", emptyBundles)));
        }

        [Test]
        public void AllBundleFilesExist()
        {
            var bundleInfos = BundleConfig.ScriptInfos.Concat(BundleConfig.StyleInfos);
            var paths = bundleInfos.SelectMany(i => i.Files).Select(MapBundlePath);
            var missing = paths.Where(path => !File.Exists(path));

            Assert.That(missing, Is.Empty, string.Format("The following bundle files are missing: {0}", string.Join(", ", missing)));
        }

        [Test]
        public void AllBundleNamesAreUnique()
        {
            var bundleInfos = BundleConfig.ScriptInfos.Concat(BundleConfig.StyleInfos);
            var names = bundleInfos.Select(i => i.Name);
            var duplicates = names.Where(name => names.Count(n => n == name) > 1).Distinct();

            Assert.That(duplicates, Is.Empty, string.Format("The following bundle names are duplicated: {0}", string.Join(", ", duplicates)));
        }

        [Test(Description = "No explicitly included files should be ignored.")]
        public void NoBundleIncludesAnIgnoredFileWithoutOptimization()
        {
            //AddDefaultIgnorePatterns(this.BundleContext.BundleCollection.IgnoreList);
            BundleTable.EnableOptimizations = false;

            this.NoBundleIncludesAnIgnoredFile();
        }

        [Test(Description = "No explicitly included files should be ignored.")]
        public void NoBundleIncludesAnIgnoredFileWithOptimization()
        {
            //AddDefaultIgnorePatterns(this.BundleContext.BundleCollection.IgnoreList);
            BundleTable.EnableOptimizations = true;

            this.NoBundleIncludesAnIgnoredFile();
        }

        private void NoBundleIncludesAnIgnoredFile()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bundleFiles = BundleTable.Bundles
                .SelectMany(bundle => bundle.EnumerateFiles(this.BundleContext));
            var ignoredFiles = bundleFiles
                .Where(fi => this.BundleContext.BundleCollection.IgnoreList.ShouldIgnore(fi.Name));
            var ignoredPaths = ignoredFiles
                .Select(fi => fi.FullName)
                .ToArray();

            Assert.That(ignoredPaths, Is.Empty, string.Format("The following bundle files will be ignored: {0}", string.Join(", ", ignoredPaths)));
        }
    }
}
