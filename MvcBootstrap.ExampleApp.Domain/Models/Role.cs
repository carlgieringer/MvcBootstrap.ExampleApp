namespace MvcBootstrap.ExampleApp.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public int Id { get; set; }

        [Required]
        public virtual string Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
    }
}