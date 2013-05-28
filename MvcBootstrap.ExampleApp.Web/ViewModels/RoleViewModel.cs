namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using MvcBootstrap.ViewModels;
    using MvcBootstrap.ViewModels.Attributes;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class RoleViewModel : EntityViewModelBase
    {
        public RoleViewModel()
        {
            this.Employees = new Choices<EmployeeOption>();
        }

        public string Title { get; set; }

        [HideIn(BootstrapAction.List)]
        public Choices<EmployeeOption> Employees { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}