namespace MvcBootstrap.ExampleApp.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MvcBootstrap.Models;

    public class Role : EntityBase
    {
        [Required]
        public virtual string Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
    }
}