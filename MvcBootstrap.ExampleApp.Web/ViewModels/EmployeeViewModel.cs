namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using MvcBootstrap.ViewModels;
    using MvcBootstrap.ViewModels.Attributes;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class EmployeeViewModel : EntityViewModelBase
    {
        public string Name { get; set; }

        public string Quest { get; set; }

        [HideIn(BootstrapAction.List)]
        public IEntityViewModelCollection Roles { get; set; }
    }
}