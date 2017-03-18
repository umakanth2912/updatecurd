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
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.DealerVehicles",
                c => new
                    {
                        DealerVehicleId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealerVehicleId)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.DealerId);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        DealerId = c.Int(nullable: false, identity: true),
                        DealerName = c.String(),
                        DealerCity = c.String(),
                        DealerCountry = c.String(),
                        DealerPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.DealerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealerVehicles", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DealerVehicles", "DealerId", "dbo.Dealers");
            DropForeignKey("dbo.Vehicles", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.DealerVehicles", new[] { "DealerId" });
            DropIndex("dbo.DealerVehicles", new[] { "VehicleId" });
            DropIndex("dbo.Vehicles", new[] { "BrandId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.Dealers");
            DropTable("dbo.DealerVehicles");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
