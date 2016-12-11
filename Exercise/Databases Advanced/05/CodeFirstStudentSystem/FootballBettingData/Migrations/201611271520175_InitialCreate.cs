namespace FootballBettingData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountyId = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountyId)
                .Index(t => t.CountyId);
            
            CreateTable(
                "dbo.CountryContinents",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 3),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CountryId, t.ContinentId })
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.ContinentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towns", "CountyId", "dbo.Countries");
            DropForeignKey("dbo.CountryContinents", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.CountryContinents", "CountryId", "dbo.Countries");
            DropIndex("dbo.CountryContinents", new[] { "ContinentId" });
            DropIndex("dbo.CountryContinents", new[] { "CountryId" });
            DropIndex("dbo.Towns", new[] { "CountyId" });
            DropTable("dbo.CountryContinents");
            DropTable("dbo.Towns");
            DropTable("dbo.Countries");
            DropTable("dbo.Continents");
        }
    }
}
