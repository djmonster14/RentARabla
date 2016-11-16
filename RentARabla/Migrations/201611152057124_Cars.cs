namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cars : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.CarBrands");
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            DropColumn("dbo.Cars", "Brand_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.CarBrands", "Id");
        }
    }
}
