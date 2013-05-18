namespace MvcBootstrap.ExampleApp.Web.Tests.DataTests
{
    using System;
    using System.Data;
    using System.IO;

    using MvcBootstrap.ExampleApp.Data;

    using NUnit.Framework;

    [TestFixture]
    public class ContextFixture
    {
        [SetUp]
        public void SetUp()
        {
            string webAppDataDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\MvcBootstrap.ExampleApp.Web\App_Data");

            // condense parent references
            webAppDataDir = Path.GetFullPath(webAppDataDir);
            AppDomain.CurrentDomain.SetData("DataDirectory", webAppDataDir);
        }

        [Test]
        public void CanConnectToDatabase()
        {
            var context = new ExampleAppContext("MvcBootstrap.ExampleApp.Web");

            Assert.That(() => context.Database.Connection.Open(), Throws.Nothing);
            Assert.That(context.Database.Connection.State, Is.EqualTo(ConnectionState.Open));
        }
    }
}
