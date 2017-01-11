namespace CreateUser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFirstnameLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
        }
    }
}
