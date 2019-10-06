namespace BudgetingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedWithGeocode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreateEvents", "Latitude", c => c.String());
            AddColumn("dbo.CreateEvents", "Longitude", c => c.String());
            AddColumn("dbo.CreateEvents", "State", c => c.String());
            AddColumn("dbo.MadeActivites", "Latitude", c => c.String());
            AddColumn("dbo.MadeActivites", "Longitude", c => c.String());
            AddColumn("dbo.MadeActivites", "City", c => c.String());
            AddColumn("dbo.MadeActivites", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MadeActivites", "State");
            DropColumn("dbo.MadeActivites", "City");
            DropColumn("dbo.MadeActivites", "Longitude");
            DropColumn("dbo.MadeActivites", "Latitude");
            DropColumn("dbo.CreateEvents", "State");
            DropColumn("dbo.CreateEvents", "Longitude");
            DropColumn("dbo.CreateEvents", "Latitude");
        }
    }
}
