namespace MvcBootstrap.ExampleApp.Web.Tests.BundleTests
{
    using System;
    using System.Web;
    using System.Web.Optimization;

    using Moq;

    using NUnit.Framework;

    internal class FixtureBase
    {
        protected BundleContext BundleContext { get; set; }

        [SetUp]
        public void SetUp()
        {
            var httpContext = new Mock<HttpContextBase>();
            this.BundleContext = new BundleContext(httpContext.Object, new BundleCollection(), string.Empty);
            BundleTable.MapPathMethod = MapBundlePath;
        }

        protected static string MapBundlePath(string item)
        {
            // todo: Replace this with whatever logic you need to map from your virtual paths to a physical path

            // Strip the ~ and switch from / to \
            item = item.Replace("~", string.Empty).Replace("/", @"\");

            // Join the item virtal path with the location of your MVC project
            const string PathToMvcProject = @"C:\Users\M29783\Documents\Visual Studio 2012\Projects\MvcBootstrap\MvcBootstrap.ExampleApp.Web";
            return string.Format("{0}{1}", PathToMvcProject, item);
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
