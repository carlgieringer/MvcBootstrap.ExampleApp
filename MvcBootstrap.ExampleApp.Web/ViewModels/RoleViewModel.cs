namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using System.Collections.Generic;

    using MvcBootstrap.ViewModels;
    using MvcBootstrap.ViewModels.Attributes;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class RoleViewModel : EntityViewModelBase
    {
        public string Title { get; set; }

        [HideIn(BootstrapAction.List)]
        public ICollection<EmployeeViewModel> Employees { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}