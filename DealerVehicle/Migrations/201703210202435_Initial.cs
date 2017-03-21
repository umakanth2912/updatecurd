namespace DealerVehicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        ModelColor = c.String(),
                        ModelYear = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VIN = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Dealers", t => t.DealerId)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .Index(t => t.ModelId)
                .Index(t => t.DealerId);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerName = c.String(),
                        DealerCity = c.String(),
                        DealerCountry = c.String(),
                        DealerPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Vehicles", "DealerId", "dbo.Dealers");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.Vehicles", new[] { "DealerId" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.Dealers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
