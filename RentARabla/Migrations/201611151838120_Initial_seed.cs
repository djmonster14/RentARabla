namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_seed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "StartLocation_Id", "dbo.Addresses");
            DropForeignKey("dbo.Rentals", "StopLocation_Id", "dbo.Addresses");
            DropIndex("dbo.Rentals", new[] { "StartLocation_Id" });
            DropIndex("dbo.Rentals", new[] { "StopLocation_Id" });
            RenameColumn(table: "dbo.CarModels", name: "CarBrandId_Id", newName: "CarBrand_Id");
            RenameIndex(table: "dbo.CarModels", name: "IX_CarBrandId_Id", newName: "IX_CarBrand_Id");
            AddColumn("dbo.Cars", "ImageUrl", c => c.String());
            AddColumn("dbo.Cars", "IsRented", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rentals", "Expired", c => c.Boolean(nullable: false));
            DropColumn("dbo.Rentals", "StartLocation_Id");
            DropColumn("dbo.Rentals", "StopLocation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "StopLocation_Id", c => c.Int());
            AddColumn("dbo.Rentals", "StartLocation_Id", c => c.Int());
            DropColumn("dbo.Rentals", "Expired");
            DropColumn("dbo.Cars", "IsRented");
            DropColumn("dbo.Cars", "ImageUrl");
            RenameIndex(table: "dbo.CarModels", name: "IX_CarBrand_Id", newName: "IX_CarBrandId_Id");
            RenameColumn(table: "dbo.CarModels", name: "CarBrand_Id", newName: "CarBrandId_Id");
            CreateIndex("dbo.Rentals", "StopLocation_Id");
            CreateIndex("dbo.Rentals", "StartLocation_Id");
            AddForeignKey("dbo.Rentals", "StopLocation_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Rentals", "StartLocation_Id", "dbo.Addresses", "Id");
        }
    }
}
