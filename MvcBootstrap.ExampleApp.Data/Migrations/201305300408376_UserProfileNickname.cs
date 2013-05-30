namespace MvcBootstrap.ExampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileNickname : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExampleUserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Username = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        LastLogin = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 128),
                        LastLogin = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ExampleUserProfiles");
        }
    }
}
