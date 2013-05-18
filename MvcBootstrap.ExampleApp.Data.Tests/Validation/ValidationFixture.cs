namespace MvcBootstrap.ExampleApp.Data.Tests.Validation
{
    using System;
    using System.Data.Entity.Validation;

    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.Testing;

    using NUnit.Framework;

    [TestFixture]
    public class ValidationFixture
    {
        private IEmployeesRepository repository;

        [SetUp]
        public void SetUp()
        {
            TestHelper.SetDataDirectoryToAppDirectory();
            var context = new ExampleAppContext("MvcBootstrap.ExampleApp.Data.ExampleAppContext");
            this.repository = new EmployeesRepository(context);
        }

        [Test]
        public void WhenEmployeeSavedWithoutNameAValidationExceptionOccurs()
        {
            var employee = this.repository.Create();
            this.repository.Add(employee);
            
            Assert.That(() => this.repository.SaveChanges(), Throws.InstanceOf<DbEntityValidationException>());
        }
    }
}
