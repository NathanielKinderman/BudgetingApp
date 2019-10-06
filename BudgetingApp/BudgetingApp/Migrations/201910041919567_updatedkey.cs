namespace BudgetingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreateEvents",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        EventsName = c.String(),
                        City = c.String(),
                        DateOfEvent = c.String(),
                        NumberOfMembers = c.String(),
                        TheBudgetOfEvent = c.String(),
                        PlannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Planners", t => t.PlannerId, cascadeDelete: true)
                .Index(t => t.PlannerId);
            
            CreateTable(
                "dbo.Planners",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Budget = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cost = c.Double(nullable: false),
                        activitesName = c.String(),
                        MadeActivitesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MadeActivites", t => t.MadeActivitesId, cascadeDelete: true)
                .Index(t => t.MadeActivitesId);
            
            CreateTable(
                "dbo.MadeActivites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameOfActivity = c.String(),
                        LocationOfActivity = c.String(),
                        TimeOfActivity = c.String(),
                        HowManyMembersInvolved = c.String(),
                        EstimatedCostOfActivity = c.String(),
                        PlannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Planners", t => t.PlannerId, cascadeDelete: true)
                .Index(t => t.PlannerId);
            
            CreateTable(
                "dbo.PartyMembers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PersonalBudget = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PartyMembers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Data", "MadeActivitesId", "dbo.MadeActivites");
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.CreateEvents", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.Planners", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PartyMembers", new[] { "ApplicationUserId" });
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            DropIndex("dbo.Data", new[] { "MadeActivitesId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Planners", new[] { "ApplicationUserId" });
            DropIndex("dbo.CreateEvents", new[] { "PlannerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PartyMembers");
            DropTable("dbo.MadeActivites");
            DropTable("dbo.Data");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Planners");
            DropTable("dbo.CreateEvents");
        }
    }
}
