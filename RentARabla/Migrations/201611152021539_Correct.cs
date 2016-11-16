namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cars", new[] { "Model_Id1" });
            DropColumn("dbo.Cars", "Model_Id");
            RenameColumn(table: "dbo.Cars", name: "Model_Id1", newName: "Model_Id");
            AlterColumn("dbo.Cars", "Model_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Model_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "Model_Id" });
            AlterColumn("dbo.Cars", "Model_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Cars", name: "Model_Id", newName: "Model_Id1");
            AddColumn("dbo.Cars", "Model_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "Model_Id1");
        }
    }
}
