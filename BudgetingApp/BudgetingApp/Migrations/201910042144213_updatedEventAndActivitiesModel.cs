namespace BudgetingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEventAndActivitiesModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreateEvents", "NumberOfMembers", c => c.Double(nullable: false));
            AlterColumn("dbo.MadeActivites", "EstimatedCostOfActivity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MadeActivites", "EstimatedCostOfActivity", c => c.String());
            AlterColumn("dbo.CreateEvents", "NumberOfMembers", c => c.String());
        }
    }
}
