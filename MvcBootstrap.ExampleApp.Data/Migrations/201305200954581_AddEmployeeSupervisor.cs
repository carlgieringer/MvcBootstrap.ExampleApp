namespace MvcBootstrap.ExampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeSupervisor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Supervisor_Id", c => c.Int());
            AddForeignKey("dbo.Employees", "Supervisor_Id", "dbo.Employees", "Id");
            CreateIndex("dbo.Employees", "Supervisor_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Supervisor_Id" });
            DropForeignKey("dbo.Employees", "Supervisor_Id", "dbo.Employees");
            DropColumn("dbo.Employees", "Supervisor_Id");
        }
    }
}
