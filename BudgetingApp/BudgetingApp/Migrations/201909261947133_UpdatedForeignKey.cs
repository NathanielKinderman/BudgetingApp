namespace BudgetingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MadeActivites", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MadeActivites", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.CreateEvents",
                c => new
                    {
                        EventsName = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        DateOfEvent = c.String(),
                        NumberOfMembers = c.String(),
                        TheBudgetOfEvent = c.String(),
                        PlannerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventsName)
                .ForeignKey("dbo.Planners", t => t.PlannerId)
                .Index(t => t.PlannerId);
            
            AddColumn("dbo.MadeActivites", "PlannerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MadeActivites", "PlannerId");
            AddForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners", "FirstName");
            DropColumn("dbo.MadeActivites", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MadeActivites", "ApplicationUserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.CreateEvents", "PlannerId", "dbo.Planners");
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            DropIndex("dbo.CreateEvents", new[] { "PlannerId" });
            DropColumn("dbo.MadeActivites", "PlannerId");
            DropTable("dbo.CreateEvents");
            CreateIndex("dbo.MadeActivites", "ApplicationUserId");
            AddForeignKey("dbo.MadeActivites", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
