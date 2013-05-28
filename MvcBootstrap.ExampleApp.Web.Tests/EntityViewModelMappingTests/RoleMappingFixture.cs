namespace MvcBootstrap.ExampleApp.Web.Tests.EntityViewModelMappingTests
{
    using AutoMapper;

    using Moq;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class RoleMappingFixture
    {
        [SetUp]
        public void Setup()
        {
            // Sets up mapping
            var context = new Mock<ExampleAppContext>();
            var repository = new Mock<IRolesRepository>();
            var employeesRepository = new Mock<IBootstrapRepository<Employee>>();
            var controller = new RolesController(repository.Object, employeesRepository.Object);
        }

        [Test]
        public void RoleEntityViewModelMappingWorks()
        {
            Assert.That(() => Mapper.AssertConfigurationIsValid(), Throws.Nothing);
        }
    }
}
