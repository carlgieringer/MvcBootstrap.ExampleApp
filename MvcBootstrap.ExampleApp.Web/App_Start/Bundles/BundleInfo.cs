namespace MvcBootstrap.ExampleApp.Web.App_Start.Bundles
{
    using System.Collections.Generic;

    public class BundleInfo
    {
        public readonly string Name;

        public readonly IEnumerable<string> Files;

        public BundleInfo(string name, IEnumerable<string> files)
        {
            this.Name = name;
            this.Files = files;
        }
    }
}