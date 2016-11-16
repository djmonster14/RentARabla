namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ignore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Model_Id", "dbo.CarModels");
            DropIndex("dbo.Cars", new[] { "Model_Id" });
            AddColumn("dbo.Cars", "Model_Id1", c => c.Int());
            AlterColumn("dbo.Cars", "Model_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "Model_Id1");
            AddForeignKey("dbo.Cars", "Model_Id1", "dbo.CarModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Model_Id1", "dbo.CarModels");
            DropIndex("dbo.Cars", new[] { "Model_Id1" });
            AlterColumn("dbo.Cars", "Model_Id", c => c.Int());
            DropColumn("dbo.Cars", "Model_Id1");
            CreateIndex("dbo.Cars", "Model_Id");
            AddForeignKey("dbo.Cars", "Model_Id", "dbo.CarModels", "Id");
        }
    }
}
