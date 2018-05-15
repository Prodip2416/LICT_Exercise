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
    public class UserVerifiedController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: UserVerified
        public ActionResult Index()
        {
            var usersVerifieds = db.UsersVerifieds.Include(u => u.User);
            return View(usersVerifieds.ToList());
        }

        // GET: UserVerified/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersVerified usersVerified = db.UsersVerifieds.Find(id);
            if (usersVerified == null)
            {
                return HttpNotFound();
            }
            return View(usersVerified);
        }

        // GET: UserVerified/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: UserVerified/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,DateTime,IP")] UsersVerified usersVerified)
        {
            if (ModelState.IsValid)
            {
                db.UsersVerifieds.Add(usersVerified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersVerified.UserId);
            return View(usersVerified);
        }

        // GET: UserVerified/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersVerified usersVerified = db.UsersVerifieds.Find(id);
            if (usersVerified == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersVerified.UserId);
            return View(usersVerified);
        }

        // POST: UserVerified/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,DateTime,IP")] UsersVerified usersVerified)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersVerified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersVerified.UserId);
            return View(usersVerified);
        }

        // GET: UserVerified/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersVerified usersVerified = db.UsersVerifieds.Find(id);
            if (usersVerified == null)
            {
                return HttpNotFound();
            }
            return View(usersVerified);
        }

        // POST: UserVerified/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersVerified usersVerified = db.UsersVerifieds.Find(id);
            db.UsersVerifieds.Remove(usersVerified);
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
