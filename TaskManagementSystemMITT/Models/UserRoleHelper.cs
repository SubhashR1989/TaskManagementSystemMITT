using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemMITT.Models
{
    public static class UserRoleHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));
        static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));

        public static void AddRole(string roleName)
        {
            if(!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole { Name = roleName });
            }

        }

        public static void DeleteRole(string roleName)
        {
            if(roleManager.RoleExists(roleName))
            {
                var role = roleManager.FindByName(roleName);
                roleManager.Delete(role);
                
            }
        }
    }
}