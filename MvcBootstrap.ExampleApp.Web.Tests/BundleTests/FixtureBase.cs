namespace MvcBootstrap.ExampleApp.Web.Tests.BundleTests
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Optimization;

    using Moq;

    using NUnit.Framework;

    internal class FixtureBase
    {
        private static readonly Regex VirtualRootRegex = new Regex(@"^~[/\\]");

        protected BundleContext BundleContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            var httpContext = new Mock<HttpContextBase>();
            this.BundleContext = new BundleContext(httpContext.Object, new BundleCollection(), string.Empty);
            BundleTable.MapPathMethod = MapBundlePath;
        }

        protected static string MapBundlePath(string itemVirtualPath)
        {
            // Use windows-style slashes
            itemVirtualPath = itemVirtualPath.Replace("/", @"\");

            // GetFullPath condenses parent references ".."
            string webProjectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\MvcBootstrap.ExampleApp.Web\"));

            // Replace the virtual path pattern with the file system path
            string itemFullPath = VirtualRootRegex.Replace(itemVirtualPath, webProjectPath);

            return itemFullPath;
        }

        protected static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Clear();
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}
