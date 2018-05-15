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
    public class UserSubscriptionController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: UserSubscription
        public ActionResult Index()
        {
            var usersSubscriptions = db.UsersSubscriptions.Include(u => u.Subscription).Include(u => u.User);
            return View(usersSubscriptions.ToList());
        }

        // GET: UserSubscription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersSubscription usersSubscription = db.UsersSubscriptions.Find(id);
            if (usersSubscription == null)
            {
                return HttpNotFound();
            }
            return View(usersSubscription);
        }

        // GET: UserSubscription/Create
        public ActionResult Create()
        {
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: UserSubscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserId,SubscriptionId,Date,ExpireDate,Remarks")] UsersSubscription usersSubscription)
        {
            var v = db.Subscriptions.Find(usersSubscription.SubscriptionId);

            usersSubscription.Date = DateTime.Now;
            usersSubscription.ExpireDate = DateTime.Now.AddDays(v.DurationDay);

            if (ModelState.IsValid)
            {
                db.UsersSubscriptions.Add(usersSubscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "id", "Name", usersSubscription.SubscriptionId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersSubscription.UserId);
            return View(usersSubscription);
        }

        // GET: UserSubscription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersSubscription usersSubscription = db.UsersSubscriptions.Find(id);
            if (usersSubscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "id", "Name", usersSubscription.SubscriptionId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersSubscription.UserId);
            return View(usersSubscription);
        }

        // POST: UserSubscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,SubscriptionId,Date,ExpireDate,Remarks")] UsersSubscription usersSubscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersSubscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "id", "Name", usersSubscription.SubscriptionId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", usersSubscription.UserId);
            return View(usersSubscription);
        }

        // GET: UserSubscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersSubscription usersSubscription = db.UsersSubscriptions.Find(id);
            if (usersSubscription == null)
            {
                return HttpNotFound();
            }
            return View(usersSubscription);
        }

        // POST: UserSubscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersSubscription usersSubscription = db.UsersSubscriptions.Find(id);
            db.UsersSubscriptions.Remove(usersSubscription);
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
