// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeesController.cs" company="Carl Gieringer">
//   Carl Gieringer
// </copyright>
// <summary>
//   Defines the EmployeesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using AutoMapper;

    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Web.Mvc.Controllers;

    /// <summary>
    /// For viewing Employees
    /// </summary>
    public class EmployeesController : BootstrapControllerBase<Employee, EmployeeViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="rolesRepository">
        /// The roles Repository.
        /// </param>
        public EmployeesController(IEmployeesRepository repository, IRolesRepository rolesRepository)
            : base(repository)
        {
            this.Config.Sort = Sort.By(e => e.Name).ThenBy(e => e.Created);
            this.Config.EntityLabelSelector = e => e.Name;
            this.Config.ViewModelLabelSelector = vm => vm.Name;
            this.Config.Relation(e => e.Roles)
                .HasOptions(e => rolesRepository.GetAll())
                .UsesLabel<RoleOption>(vm => vm.Title);
            this.Config.Relation(e => e.Supervisor)
                .HasOptions(e => repository.GetAll())
                .UsesLabel<EmployeeOption>(vm => vm.Name)
                .CanChooseSelf(false);
        }
    }
}
