using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDJArticle15.Models;

namespace BDJArticle15.Controllers
{
    public class UserAdminController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: UserAdmin
        public ActionResult Index()
        {
            var usersAdmins = db.UsersAdmins.Include(u => u.User);
            return View(usersAdmins.ToList());
        }

        // GET: UserAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmin usersAdmin = db.UsersAdmins.Find(id);
            if (usersAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usersAdmin);
        }

        // GET: UserAdmin/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: UserAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,DateTime,IP")] UsersAdmin usersAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UsersAdmins.Add(usersAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAdmin.UserId);
            return View(usersAdmin);
        }

        // GET: UserAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmin usersAdmin = db.UsersAdmins.Find(id);
            if (usersAdmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAdmin.UserId);
            return View(usersAdmin);
        }

        // POST: UserAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,DateTime,IP")] UsersAdmin usersAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAdmin.UserId);
            return View(usersAdmin);
        }

        // GET: UserAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmin usersAdmin = db.UsersAdmins.Find(id);
            if (usersAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usersAdmin);
        }

        // POST: UserAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersAdmin usersAdmin = db.UsersAdmins.Find(id);
            db.UsersAdmins.Remove(usersAdmin);
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
