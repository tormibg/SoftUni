namespace ManyToMany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemovingFK : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "Town_Id" });
            DropIndex("dbo.Students", new[] { "Town_Id1" });
            DropIndex("dbo.Students", new[] { "BornTown_Id" });
            DropIndex("dbo.Students", new[] { "LivingTown_Id" });
            DropForeignKey("dbo.Students", "FK_dbo.Students_dbo.Towns_BornTown_Id");
            DropForeignKey("dbo.Students", "FK_dbo.Students_dbo.Towns_LivingTown_Id");
            DropColumn("dbo.Students", "BornTown_Id");
            DropColumn("dbo.Students", "LivingTown_Id");
            RenameColumn(table: "dbo.Students", name: "Town_Id", newName: "BornTown_Id");
            RenameColumn(table: "dbo.Students", name: "Town_Id1", newName: "LivingTown_Id");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.Students", name: "LivingTown_Id", newName: "Town_Id1");
            RenameColumn(table: "dbo.Students", name: "BornTown_Id", newName: "Town_Id");
            AddColumn("dbo.Students", "LivingTown_Id", c => c.Int());
            AddColumn("dbo.Students", "BornTown_Id", c => c.Int());
            CreateIndex("dbo.Students", "Town_Id1");
            CreateIndex("dbo.Students", "Town_Id");
        }
    }
}
