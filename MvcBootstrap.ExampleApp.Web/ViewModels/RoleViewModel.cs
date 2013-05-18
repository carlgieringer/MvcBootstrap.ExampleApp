namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using System.Collections.Generic;

    using MvcBootstrap.ViewModels;

    public class RoleViewModel : EntityViewModelBase
    {
        public string Title { get; set; }

        public ICollection<EmployeeViewModel> Employees { get; set; } 
    }
}