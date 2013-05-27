namespace MvcBootstrap.ExampleApp.Web.ViewModels
{
    using MvcBootstrap.ViewModels;

    public class RoleOption : EntityViewModelBase
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}