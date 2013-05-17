using System.Data.Entity;
using MvcBootstrap.ExampleApp.Domain.Models;

namespace MvcBootstrap.ExampleApp.Data
{
    public class ExampleAppContext : DbContext
    {
        public ExampleAppContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Roles)
                .WithMany(r => r.Employees);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
        }
    }
}