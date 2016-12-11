namespace InClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAddresses", "Id", "dbo.Students");
            DropIndex("dbo.StudentAddresses", new[] { "Id" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentAddresses");
        }
    }
}
