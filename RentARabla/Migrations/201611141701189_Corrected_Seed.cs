namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrected_Seed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Administrator", "Person_Id", "dbo.People");
            DropIndex("dbo.Administrator", new[] { "Person_Id" });
            DropColumn("dbo.Administrator", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Administrator", "Person_Id", c => c.Int());
            CreateIndex("dbo.Administrator", "Person_Id");
            AddForeignKey("dbo.Administrator", "Person_Id", "dbo.People", "Id");
        }
    }
}
