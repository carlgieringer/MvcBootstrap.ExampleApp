namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Mapping;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class RolesController : BootstrapControllerBase<Role ,RoleViewModel>
    {
        public RolesController(IBootstrapRepository<Role> repository)
            : base(repository)
        {
            MappingHelper.CreateEntityToViewModelMap<Employee, EmployeeViewModel>();
            MappingHelper.CreateViewModelToEntityMap<EmployeeViewModel, Employee>();
        }
    }
}
