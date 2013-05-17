namespace MvcBootstrap.ExampleApp.Data.Tests
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using MvcBootstrap.ExampleApp.Data.Repositories;

    using NUnit.Framework;

    [TestFixture]
    public class ConcurrencyTests
    {
        private const string TestConnString = @"Data Source=(localdb)\v11.0;Integrated Security=true;Initial Catalog=MvcBootstrapExample.Tests";

        [SetUp]
        public void SetUp()
        {
            var context = new ExampleAppContext(TestConnString);
            context.Database.Delete();

            var repository = new EmployeesRepository(context);

            var employee = repository.Create();
            employee.Name = "Fred";
            repository.Add(employee);
            repository.SaveChanges();
        }

        [Test]
        public void OptomisticConcurrencyWorks()
        {
            var repository1 = new EmployeesRepository(new ExampleAppContext(TestConnString));
            var employee1 = repository1.Items.Single(e => e.Name == "Fred");

            var repository2 = new EmployeesRepository(new ExampleAppContext(TestConnString));
            var employee2 = repository2.Items.Single(e => e.Name == "Fred");

            Assert.That(employee1.Id, Is.EqualTo(employee2.Id));

            employee1.Name = "Wilma";
            repository1.Update(employee1);
            repository1.SaveChanges();

            employee2.Name = "Barney";
            repository2.Update(employee2);
            Assert.That(() => repository2.SaveChanges(), Throws.InstanceOf<DbUpdateConcurrencyException>());
        }
    }
}
