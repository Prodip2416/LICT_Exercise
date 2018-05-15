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
    public class SubscriptionTypeController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: SubscriptionType
        public ActionResult Index()
        {
            return View(db.SubscriptionTypes.ToList());
        }

        // GET: SubscriptionType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionType subscriptionType = db.SubscriptionTypes.Find(id);
            if (subscriptionType == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionType);
        }

        // GET: SubscriptionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Description")] SubscriptionType subscriptionType)
        {
            if (ModelState.IsValid)
            {
                db.SubscriptionTypes.Add(subscriptionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscriptionType);
        }

        // GET: SubscriptionType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionType subscriptionType = db.SubscriptionTypes.Find(id);
            if (subscriptionType == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionType);
        }

        // POST: SubscriptionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Description")] SubscriptionType subscriptionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriptionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscriptionType);
        }

        // GET: SubscriptionType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionType subscriptionType = db.SubscriptionTypes.Find(id);
            if (subscriptionType == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionType);
        }

        // POST: SubscriptionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubscriptionType subscriptionType = db.SubscriptionTypes.Find(id);
            db.SubscriptionTypes.Remove(subscriptionType);
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
