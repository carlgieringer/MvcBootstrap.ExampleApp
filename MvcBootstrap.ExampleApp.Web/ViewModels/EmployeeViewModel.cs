namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using MvcBootstrap.ViewModels;
    using MvcBootstrap.ViewModels.Attributes;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class EmployeeViewModel : EntityViewModelBase
    {
        public EmployeeViewModel()
        {
            this.Roles = new Choices<RoleOption>();
            this.Supervisor = new Choice<EmployeeOption>();
        }

        [Required]
        public string Name { get; set; }

        public string Quest { get; set; }

        public Choice<EmployeeOption> Supervisor { get; set; }

        [HideIn(BootstrapActions.List)]
        public Choices<RoleOption> Roles { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}