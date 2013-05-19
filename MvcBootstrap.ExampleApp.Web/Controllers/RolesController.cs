namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class RolesController : BootstrapControllerBase<Role ,RoleViewModel>
    {
        public RolesController(IRolesRepository repository)
            : base(repository)
        {
            this.CreateEntityToViewModelMap<Employee, EmployeeViewModel>();
            this.CreateViewModelToEntityMap<EmployeeViewModel, Employee>();
        }
    }
}
