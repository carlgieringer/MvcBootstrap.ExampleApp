namespace MvcBootstrap.ExampleApp.Data
{
    using System.Data.Entity;

    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.Properties;

    public class ExampleAppContext : DbContext
    {
        /// <summary>
        /// The name of the connection string in the Web.config
        /// </summary>
        /// <remarks>
        /// Must equal <see cref="ExampleAppContext"/>'s fully-qualified name if 
        /// <see cref="ExampleAppContext"/> resides in a different assembly from the web 
        /// application in order for the One-Click Deploy dialog to recognize this context
        /// as code-first.
        /// </remarks>
        public const string ConnectionStringName = "MvcBootstrap.ExampleApp.Data.ExampleAppContext";

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAppContext"/> class. 
        /// </summary>
        /// <remarks>
        /// Used by Entity Framework code-first migrations
        /// </remarks>
        [UsedImplicitly]
        public ExampleAppContext()
            : base(ConnectionStringName)
        {
        }

        public ExampleAppContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExampleUserProfile>();

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