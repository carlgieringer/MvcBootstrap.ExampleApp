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
    using System.Collections.Generic;
    using System.Web.Security;

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
            this.Config.Sort = Sort.By(e => e.Name).ThenBy(e => e.Id);
            // TODO why do we need a label for an entity?  ViewModels are the things that are shown to the user.
            this.Config.EntityLabelSelector = e => e.Name;
            this.Config.ViewModelLabelSelector = vm => vm.Name;
            this.Config.RelatedEntities()
                .For(e => e.Roles)
                .UseSource(e => rolesRepository.Items)
                .WithLabel<RoleViewModel>(r => r.Title);

            this.CreateEntityToViewModelMap<Role, RoleViewModel>();
            this.CreateViewModelToEntityMap<RoleViewModel, Role>();
            this.CreateRelatedEntityCollectionToViewModelCollectionMap<Role, RoleViewModel>();
            
            this.ViewModelToEntityMappingExpression.ForMember(e => e.Roles, o => o.Ignore());
        }
    }
}
