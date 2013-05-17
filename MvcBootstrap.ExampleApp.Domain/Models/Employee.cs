namespace MvcBootstrap.ExampleApp.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MvcBootstrap.Models;

    public class Employee : EntityBase
    {
        [Required]
        public virtual string Name { get; set; }

        public virtual string Quest { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}