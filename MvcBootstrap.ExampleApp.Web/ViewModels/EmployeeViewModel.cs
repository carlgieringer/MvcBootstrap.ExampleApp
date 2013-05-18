namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using System.Collections.Generic;

    using MvcBootstrap.ViewModels;

    public class EmployeeViewModel : EntityViewModelBase
    {
        public string Name { get; set; }

        public string Quest { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}