﻿using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementSystemMITT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Notifications = new HashSet<Notification>();
            Projects = new HashSet<Project>();
            Tasks = new HashSet<ProjectTask>();   
        }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }*/

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {         
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}