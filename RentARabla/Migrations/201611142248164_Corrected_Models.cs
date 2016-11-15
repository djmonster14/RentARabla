namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrected_Models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CarType", c => c.String());
            AlterColumn("dbo.Cars", "Brand", c => c.String());
            AlterColumn("dbo.Cars", "Model", c => c.String());
            DropColumn("dbo.Cars", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Model", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Brand", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "CarType");
        }
    }
}
