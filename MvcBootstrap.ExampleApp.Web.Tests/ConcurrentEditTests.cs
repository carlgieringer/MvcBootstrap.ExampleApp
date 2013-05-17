namespace MvcBootstrap.ExampleApp.Web.Tests
{
    using System.Web.Mvc;

    using Moq;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.Controllers;
    using MvcBootstrap.ExampleApp.Web.ViewModels;

    using NUnit.Framework;

    [TestFixture]
    public class ConcurrentEditTests
    {
        [Test]
        public void ConcurrentUpdateExceptionReturnsViewModelForConcurrentlyEditedEntity()
        {
            // Arrange
            var entity = new Employee
                {
                    Name = "Fred",
                    Quest = "To eat brontoburgers."
                };
            var repository = new Mock<IEmployeesRepository>();
            repository.Setup(r => r.GetById(1)).Returns(() => entity);
            repository.Setup(r => r.SaveChanges()).Throws(new ConcurrentUpdateException(entity));
            var controller = new EmployeesController(repository.Object);
            var viewModel = new EmployeeViewModel
                {
                    Id = 1,
                    Name = "Fred",
                    ConcurrentlyEdited = null,
                    Quest = "Brontosaurus burgers hoooo!"
                };

            // Act
            var response = controller.Update(viewModel) as ViewResult;

            // Secondary Assertions
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Model, Is.Not.Null);
            Assert.That(response.Model, Is.TypeOf<EmployeeViewModel>());

            var responseViewModel = response.Model as EmployeeViewModel;
            Assert.That(responseViewModel, Is.Not.Null);

            // Primary Assertion
            Assert.That(responseViewModel.ConcurrentlyEdited, Is.Not.Null);
        }
    }
}
