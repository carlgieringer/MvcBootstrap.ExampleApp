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
    using System.Linq;
    using System.Web.Mvc;

    using MvcBootstrap.Data;
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
            this.Config.EntityLabelSelector = e => e.Name;
            this.Config.ViewModelLabelSelector = vm => vm.Name;
            this.Config.RelatedEntities()
                .Relation(e => e.Roles)
                .HasChoices(e => rolesRepository.Items)
                .UsesLabel<RoleViewModel>(r => r.Title);

            /* 
             * TODO this could probably all be automated by reflecting on which members with the same name (or which would map to each other)
             * are IEntity/IEnumerable<IEntity> (on Employee) and 
             * IEntityViewModel/IEnumerable<IEntityViewModel>/ChoiceCollection (on EmployeeViewModel)
             */

            this.CreateEntityToViewModelMap<Role, RoleViewModel>()
                // Don't map the related Employees, because that begins an infinite cycle
                .ForMember(vm => vm.Employees, o => o.Ignore());
            this.CreateViewModelToEntityMap<RoleViewModel, Role>()
                .ForMember(r => r.Employees, o => o.Ignore());

            var roleRepository = DependencyResolver.Current.GetService<IBootstrapRepository<Role>>();
            this.CreateRelatedEntityCollectionToChoiceCollectionMap<Role, RoleViewModel>();
            this.CreateChoiceCollectionToEntityCollectionMap<RoleViewModel, Role>(roleRepository);
        }
    }
}
