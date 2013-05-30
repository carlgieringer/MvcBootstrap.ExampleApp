namespace MvcBootstrap.ExampleApp.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    using MvcBootstrap.Models;

    public class UserProfile : UserProfileBase
    {
        [DataType(DataType.EmailAddress), Required]
        public virtual string Email { get; set; }
    }
}
