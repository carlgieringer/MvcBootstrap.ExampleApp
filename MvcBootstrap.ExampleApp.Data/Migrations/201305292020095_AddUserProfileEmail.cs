namespace MvcBootstrap.ExampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Email");
        }
    }
}
