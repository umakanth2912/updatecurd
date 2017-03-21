namespace DealerVehicle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVehicleProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VIN", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VIN", c => c.Int(nullable: false));
        }
    }
}
