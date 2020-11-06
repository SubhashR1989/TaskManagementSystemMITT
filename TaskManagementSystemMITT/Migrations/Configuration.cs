namespace TaskManagementSystemMITT.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI.WebControls;
    using TaskManagementSystemMITT.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagementSystemMITT.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManagementSystemMITT.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            /*Roles for Developer and Manager*/
            if (!context.Roles.Any(r => r.Name == "Developer"))/*Developer Role*/
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Developer" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Manager"))/*Manager Role*/
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            /*------------------------------------------------------------------------------------------------------*/
            /*Creating and adding one user to each role*/
            if (!context.Users.Any(u => u.UserName == "developer@mysite.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser
                {
                    UserName = "developer@mysite.com",
                    Email = "developer@mysite.com",
                    PasswordHash = PasswordHash.HashPassword("123456")
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Developer");
            }
            if (!context.Users.Any(u => u.UserName == "manager@mysite.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var PasswordHash = new PasswordHasher();
                var user = new ApplicationUser
                {
                    UserName = "manager@mysite.com",
                    Email = "manager@mysite.com",
                    PasswordHash = PasswordHash.HashPassword("123456")
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Manager");
            }

            /*------------------------------------------------------------------------------------------------------*/
            /*Creating a Project*/
            Project[] projects =
            {
                new Project
                {                   
                    Name = "TaskManagementSystemtMITT",                                   
                }
            };
            context.Projects.AddOrUpdate(t => t.Name, projects);


            /*------------------------------------------------------------------------------------------------------*/
            /*Creating two Tasks*/
            ProjectTask[] tasks =
            {
                new ProjectTask
                {                  
                    Name = "Seed method",
                    Description = "Writing seed method for task management system",                                   
                    StartDateTime = DateTime.Parse("05/11/2020", new System.Globalization.CultureInfo("pt-BR")),
                    EndDateTime = DateTime.Parse("15/11/2020", new System.Globalization.CultureInfo("pt-BR")),
                    IsCompleted = false,
                    Priority = Priority.High,
                },

                new ProjectTask
                {                   
                    Name = "Project Helper view",
                    Description = "Creating project helper controller and view for task management system",
                    StartDateTime = DateTime.Parse("07/11/2020", new System.Globalization.CultureInfo("pt-BR")),
                    EndDateTime = DateTime.Parse("12/11/2020", new System.Globalization.CultureInfo("pt-BR")),
                    IsCompleted = true,
                    Priority = Priority.Medium,
                }
            };
            context.Tasks.AddOrUpdate(t => t.Description, tasks);
           
        }
    }
}
