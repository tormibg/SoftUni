namespace ManyToMany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.School_Id);
            
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
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentStudents",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Student_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Student_Id1 })
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id1)
                .Index(t => t.Student_Id)
                .Index(t => t.Student_Id1);
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Student_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.StudentAddresses", "Id", "dbo.Students");
            DropForeignKey("dbo.StudentStudents", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.StudentStudents", "Student_Id", "dbo.Students");
            DropIndex("dbo.SubjectStudents", new[] { "Student_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_Id" });
            DropIndex("dbo.StudentStudents", new[] { "Student_Id1" });
            DropIndex("dbo.StudentStudents", new[] { "Student_Id" });
            DropIndex("dbo.StudentAddresses", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "School_Id" });
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.StudentStudents");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentAddresses");
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
        }
    }
}
