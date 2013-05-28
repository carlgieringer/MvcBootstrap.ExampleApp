namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class RolesController : BootstrapControllerBase<Role, RoleViewModel>
    {
        public RolesController(IRolesRepository repository, IBootstrapRepository<Employee> employeesRepository)
            : base(repository)
        {
            this.Config.Sort = Sort.By(e => e.Title).ThenBy(e => e.Created);
            this.Config.EntityLabelSelector = e => e.Title;
            this.Config.ViewModelLabelSelector = vm => vm.Title;
            this.Config.Relation(e => e.Employees)
                .HasOptions(e => employeesRepository.Items)
                .UsesLabel<EmployeeOption>(vm => vm.Name);
            //this.Config.Relation(e => e.ParentRole)
            //    .HasOptions(e => repository.Items)
            //    .UsesLabel<RoleOption>(vm => vm.Title)
            //    .CanChooseSelf(false);
        }
    }
}
