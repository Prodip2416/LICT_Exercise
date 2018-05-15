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
    public class AddManagerController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: AddManager
        public ActionResult Index()
        {
            return View(db.AddManagers.ToList());
        }

        // GET: AddManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddManager addManager = db.AddManagers.Find(id);
            if (addManager == null)
            {
                return HttpNotFound();
            }
            return View(addManager);
        }

        // GET: AddManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Title,Description,rawHtml,height,width,link,viewCount,clickCount")] AddManager addManager)
        {
            if (ModelState.IsValid)
            {
                db.AddManagers.Add(addManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addManager);
        }

        // GET: AddManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddManager addManager = db.AddManagers.Find(id);
            if (addManager == null)
            {
                return HttpNotFound();
            }
            return View(addManager);
        }

        // POST: AddManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Title,Description,rawHtml,height,width,link,viewCount,clickCount")] AddManager addManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addManager);
        }

        // GET: AddManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddManager addManager = db.AddManagers.Find(id);
            if (addManager == null)
            {
                return HttpNotFound();
            }
            return View(addManager);
        }

        // POST: AddManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddManager addManager = db.AddManagers.Find(id);
            db.AddManagers.Remove(addManager);
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
