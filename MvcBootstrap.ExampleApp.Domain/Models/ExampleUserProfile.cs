namespace MvcBootstrap.ExampleApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    using MvcBootstrap.Models;

    public class ExampleUserProfile : UserProfile
    {
        public string Nickname { get; set; }

        public override string ToString()
        {
            return this.Username;
        }
    }
}
