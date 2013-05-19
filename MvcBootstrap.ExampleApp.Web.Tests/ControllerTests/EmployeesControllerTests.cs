namespace MvcBootstrap.ExampleApp.Web.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Moq;

    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.Controllers;
    using MvcBootstrap.ExampleApp.Web.ViewModels;

    using NUnit.Framework;

    [TestFixture]
    public class EmployeesControllerTests
    {
        [Test]
        public void TestListWorks()
        {
            var employees = new List<Employee>
                {
                    new Employee
                        {
                            Name = "Bob"
                        },
                    new Employee
                        {
                            Name = "Jane"
                        }
                };

            var repository = new Mock<IEmployeesRepository>();
            repository.Setup(r => r.Items).Returns(employees.AsQueryable());
            var rolesRepository = new Mock<IRolesRepository>();

            var controller = new EmployeesController(repository.Object, rolesRepository.Object);
            var result = controller.List() as ViewResult;

            var model = result.ViewData.Model as IEnumerable<EmployeeViewModel>;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestDetailsWorks()
        {
            var bob = new Employee
                {
                    Name = "Bob"
                };

            var repository = new Mock<IEmployeesRepository>();
            repository.Setup(r => r.GetById(1)).Returns(bob);
            var rolesRepository = new Mock<IRolesRepository>();

            var controller = new EmployeesController(repository.Object, rolesRepository.Object);
            var result = controller.Read(1) as ViewResult;

            var model = result.ViewData.Model as EmployeeViewModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.TypeOf<EmployeeViewModel>());
        }

        [Test]
        public void TestEditWorks()
        {
            var bob = new Employee
                {
                    Name = "Bob"
                };

            var repository = new Mock<IEmployeesRepository>();
            repository.Setup(r => r.GetById(It.IsAny<int>())).Returns(bob);
            var rolesRepository = new Mock<IRolesRepository>();

            var controller = new EmployeesController(repository.Object, rolesRepository.Object);
            var result = controller.Update(1) as ViewResult;

            var model = result.ViewData.Model as EmployeeViewModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.TypeOf<EmployeeViewModel>());
        }

        [Test]
        public void TestListMappingWorks()
        {
            var employees = new List<Employee>
                {
                    new Employee
                        {
                            Name = "Bob"
                        }
                };

            var repository = new Mock<IEmployeesRepository>();
            repository.Setup(r => r.Items).Returns(employees.AsQueryable());
            var rolesRepository = new Mock<IRolesRepository>();

            var controller = new EmployeesController(repository.Object, rolesRepository.Object);
            var result = controller.List() as ViewResult;

            var model = result.ViewData.Model as IEnumerable<EmployeeViewModel>;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Count(), Is.EqualTo(1));
            Assert.That(model.Single().Name, Is.EqualTo("Bob"));
        }
    }
}
