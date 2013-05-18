namespace MvcBootstrap.ExampleApp.Web.Tests.EntityViewModelMappingTests
{
    using AutoMapper;

    using Moq;

    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class EmployeeMappingFixture
    {
        [SetUp]
        public void Setup()
        {
            // Sets up mapping
            var context = new Mock<ExampleAppContext>();
            var repository = new Mock<IEmployeesRepository>();
            var controller = new EmployeesController(repository.Object);
        }

        [Test]
        public void EmployeeEntityViewModelMappingWorks()
        {
            Assert.That(() => Mapper.AssertConfigurationIsValid(), Throws.Nothing);
        }
    }
}
