namespace MvcBootstrap.ExampleApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileUserNameRequiredAndUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Username", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserProfiles", "Username", unique: true, name: "UQ_UserProfiles_Username");
        }
        
        public override void Down()
        {
            this.DropIndex("dbo.UserProfiles", "UQ_UserProfiles_Username");
            AlterColumn("dbo.UserProfiles", "Username", c => c.String());
        }
    }
}
