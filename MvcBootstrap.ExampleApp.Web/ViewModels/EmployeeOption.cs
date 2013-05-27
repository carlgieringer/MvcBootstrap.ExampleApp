namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using MvcBootstrap.ViewModels;

    public class EmployeeOption : EntityViewModelBase
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}