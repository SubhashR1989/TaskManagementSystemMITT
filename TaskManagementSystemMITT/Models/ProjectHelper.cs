using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemMITT.Models
{
    public static class ProjectHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        public static bool CreateProject(string name, string projectManagerId)
        {
            if (db.Projects.Any(p => p.Name == name))
            {
                return false;
            }
            db.Projects.Add(new Project() { Name = name, UserId = projectManagerId });
            return true;
        }

        public static bool DeleteProject(int id)
        {
            if (db.Projects.Any(p => p.Id == id))
            {
                var proj = db.Projects.Find(id);
                db.Projects.Remove(proj);
                return true;
            }
            return false;
        }

        public static bool EditProject(int id, string name)
        {
            if (db.Projects.Any(p => p.Id == id) && !db.Projects.Any(p => p.Name == name))
            {
                var proj = db.Projects.Find(id);
                proj.Name = name;
                return true;
            }
            return false;
        }

        public static List<ProjectTask> AllTasksByProject(int id)
        {
            return db.Projects.Find(id).ProjectTasks.ToList();
        }
    }
}