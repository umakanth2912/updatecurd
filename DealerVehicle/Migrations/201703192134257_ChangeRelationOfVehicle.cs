namespace DealerVehicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationOfVehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "BrandId", "dbo.Brands");
            DropIndex("dbo.Vehicles", new[] { "BrandId" });
            AddColumn("dbo.Vehicles", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "ModelId");
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.Models", "ModelId");
            DropColumn("dbo.Vehicles", "BrandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "BrandId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropColumn("dbo.Vehicles", "ModelId");
            CreateIndex("dbo.Vehicles", "BrandId");
            AddForeignKey("dbo.Vehicles", "BrandId", "dbo.Brands", "BrandId");
        }
    }
}
