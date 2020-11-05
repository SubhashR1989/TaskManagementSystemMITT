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
    public class DevDashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DevDashboard
        public ActionResult Index(string userId)
        {
            var results = TaskHelper.GetAllTaskByUser(userId).ToList();
            
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

        // GET: DevDashboard/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: DevDashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDateTime,EndDateTime,ProjectId,UserId,IsCompleted,Priority")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(projectTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", projectTask.UserId);
            return View(projectTask);
        }

        // GET: DevDashboard/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", projectTask.UserId);
            return View(projectTask);
        }

        // POST: DevDashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDateTime,EndDateTime,ProjectId,UserId,IsCompleted,Priority")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", projectTask.UserId);
            return View(projectTask);
        }

        // GET: DevDashboard/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: DevDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTask projectTask = db.Tasks.Find(id);
            db.Tasks.Remove(projectTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
