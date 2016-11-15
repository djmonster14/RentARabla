namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Brands : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        CarBrandId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.CarBrandId_Id)
                .Index(t => t.CarBrandId_Id);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.l_CarTypeBrand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarBrandId_Id = c.Int(),
                        CarTypeId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.CarBrandId_Id)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeId_Id)
                .Index(t => t.CarBrandId_Id)
                .Index(t => t.CarTypeId_Id);
            
            AddColumn("dbo.Cars", "Brand_Id", c => c.Int());
            AddColumn("dbo.Cars", "Model_Id", c => c.Int());
            AddColumn("dbo.Cars", "Type_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_Id");
            CreateIndex("dbo.Cars", "Model_Id");
            CreateIndex("dbo.Cars", "Type_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.CarBrands", "Id");
            AddForeignKey("dbo.Cars", "Model_Id", "dbo.CarModels", "Id");
            AddForeignKey("dbo.Cars", "Type_Id", "dbo.CarTypes", "Id");
            DropColumn("dbo.Cars", "CarType");
            DropColumn("dbo.Cars", "Brand");
            DropColumn("dbo.Cars", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Model", c => c.String());
            AddColumn("dbo.Cars", "Brand", c => c.String());
            AddColumn("dbo.Cars", "CarType", c => c.String());
            DropForeignKey("dbo.l_CarTypeBrand", "CarTypeId_Id", "dbo.CarTypes");
            DropForeignKey("dbo.l_CarTypeBrand", "CarBrandId_Id", "dbo.CarBrands");
            DropForeignKey("dbo.Cars", "Type_Id", "dbo.CarTypes");
            DropForeignKey("dbo.Cars", "Model_Id", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarBrandId_Id", "dbo.CarBrands");
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.CarBrands");
            DropIndex("dbo.l_CarTypeBrand", new[] { "CarTypeId_Id" });
            DropIndex("dbo.l_CarTypeBrand", new[] { "CarBrandId_Id" });
            DropIndex("dbo.CarModels", new[] { "CarBrandId_Id" });
            DropIndex("dbo.Cars", new[] { "Type_Id" });
            DropIndex("dbo.Cars", new[] { "Model_Id" });
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            DropColumn("dbo.Cars", "Type_Id");
            DropColumn("dbo.Cars", "Model_Id");
            DropColumn("dbo.Cars", "Brand_Id");
            DropTable("dbo.l_CarTypeBrand");
            DropTable("dbo.CarTypes");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarBrands");
        }
    }
}
