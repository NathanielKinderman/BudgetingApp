﻿using BudgetingApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetingApp.Startup))]
namespace BudgetingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = " ";
                user.Email = " ";

                string userPWD = " ";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }       
                                                         
            // creating Creating Manager role    
            if (!roleManager.RoleExists("Planner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Planner";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("PartyMember"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "PartyMemeber";
                roleManager.Create(role);

            }
        }
    }
}
