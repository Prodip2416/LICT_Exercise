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
    public class UserAuthorController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: UserAuthor
        public ActionResult Index()
        {
            var usersAuthors = db.UsersAuthors.Include(u => u.User);
            return View(usersAuthors.ToList());
        }

        // GET: UserAuthor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAuthor usersAuthor = db.UsersAuthors.Find(id);
            if (usersAuthor == null)
            {
                return HttpNotFound();
            }
            return View(usersAuthor);
        }

        // GET: UserAuthor/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: UserAuthor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,DateTime,IP")] UsersAuthor usersAuthor)
        {
            usersAuthor.IP = Request.UserHostAddress;
            usersAuthor.DateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.UsersAuthors.Add(usersAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAuthor.UserId);
            return View(usersAuthor);
        }

        // GET: UserAuthor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAuthor usersAuthor = db.UsersAuthors.Find(id);
            if (usersAuthor == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAuthor.UserId);
            return View(usersAuthor);
        }

        // POST: UserAuthor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,DateTime,IP")] UsersAuthor usersAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersAuthor.UserId);
            return View(usersAuthor);
        }

        // GET: UserAuthor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAuthor usersAuthor = db.UsersAuthors.Find(id);
            if (usersAuthor == null)
            {
                return HttpNotFound();
            }
            return View(usersAuthor);
        }

        // POST: UserAuthor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersAuthor usersAuthor = db.UsersAuthors.Find(id);
            db.UsersAuthors.Remove(usersAuthor);
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
