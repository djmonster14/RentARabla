namespace RentARabla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_Client : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Client", "Person_Id", "dbo.People");
            DropIndex("dbo.Client", new[] { "Person_Id" });
            DropColumn("dbo.Client", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "Person_Id", c => c.Int());
            CreateIndex("dbo.Client", "Person_Id");
            AddForeignKey("dbo.Client", "Person_Id", "dbo.People", "Id");
        }
    }
}
