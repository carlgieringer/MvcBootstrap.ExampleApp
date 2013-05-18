namespace MvcBootstrap.ExampleApp.Data.Tests.ConcurrentUpdates
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.Testing;

    using NUnit.Framework;

    [TestFixture]
    public class ConcurrentUpdatesFixture
    {
        [SetUp]
        public void SetUp()
        {
            TestHelper.SetDataDirectoryToAppDirectory();

            var context = new ExampleAppContext("MvcBootstrap.ExampleApp.Data.Tests");
            context.Database.Delete();

            var repository = new EmployeesRepository(context);

            var employee = repository.Create();
            employee.Name = "Fred";
            repository.Add(employee);
            repository.SaveChanges();
        }

        [Test]
        public void ConcurrentUpdateThrowsException()
        {
            var repository1 = new EmployeesRepository(new ExampleAppContext("MvcBootstrap.ExampleApp.Data.Tests"));
            var employee1 = repository1.Items.Single(e => e.Name == "Fred");

            var repository2 = new EmployeesRepository(new ExampleAppContext("MvcBootstrap.ExampleApp.Data.Tests"));
            var employee2 = repository2.Items.Single(e => e.Name == "Fred");

            Assert.That(employee1.Id, Is.EqualTo(employee2.Id));

            employee1.Name = "Wilma";
            repository1.Update(employee1);
            repository1.SaveChanges();

            employee2.Name = "Barney";
            repository2.Update(employee2);
            Assert.That(() => repository2.SaveChanges(), Throws.InstanceOf<ConcurrentUpdateException>());
        }
    }
}
