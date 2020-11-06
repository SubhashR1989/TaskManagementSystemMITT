using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystemMITT.Models;

namespace TaskManagementSystemMITT.Controllers
{
    //[Authorize(Roles = "Developer,Project Manager")]
    [Authorize]
    public class DevDashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DevDashboard
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var results = TaskHelper.GetAllTaskByUser(user.Id).ToList();
            ViewBag.Username = user.UserName;

            return View(results);
        }

        // GET: DevDashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.Tasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        public ActionResult MarkComplete(int taskId)
        {
            var task = db.Tasks.Find(taskId);
            if (!task.IsCompleted)
            {
                task.IsCompleted = true;
            }
            return View();
        }

    }
}
