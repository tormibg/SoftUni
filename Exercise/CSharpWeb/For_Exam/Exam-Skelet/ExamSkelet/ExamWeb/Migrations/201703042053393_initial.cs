namespace ExamWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 450),
                        Email = c.String(maxLength: 450),
                        Password = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true, name: "Email");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", "Email");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
        }
    }
}
