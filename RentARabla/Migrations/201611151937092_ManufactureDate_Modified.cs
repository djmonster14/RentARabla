namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufactureDate_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ManufactureDateTmp", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "ManufactureDate");
            RenameColumn("dbo.Cars", "ManufactureDateTmp", "ManufactureDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "ManufactureDateTmp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cars", "ManufactureDate");
            RenameColumn("dbo.Cars", "ManufactureDateTmp", "ManufactureDate");
        }
    }
}
