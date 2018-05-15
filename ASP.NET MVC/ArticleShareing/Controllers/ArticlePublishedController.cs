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
    public class ArticlePublishedController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticlePublished
        public ActionResult Index()
        {
            var articlePublisheds = db.ArticlePublisheds;
            return View(articlePublisheds.ToList());
        }

        // GET: ArticlePublished/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlePublished articlePublished = db.ArticlePublisheds.Find(id);
            if (articlePublished == null)
            {
                return HttpNotFound();
            }
            return View(articlePublished);
        }

        // GET: ArticlePublished/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.vwArticleUnPublisheds, "id", "title");
            return View();
        }

        // POST: ArticlePublished/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticlePublished articlePublished)
        {
            articlePublished.UserId = (int)Session["id"];
            articlePublished.DateTime = DateTime.Now;
            articlePublished.IP = Request.UserHostAddress;

            if (ModelState.IsValid)
            {
                db.ArticlePublisheds.Add(articlePublished);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articlePublished.ArticleId);
            return View(articlePublished);
        }

        // GET: ArticlePublished/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlePublished articlePublished = db.ArticlePublisheds.Find(id);
            if (articlePublished == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articlePublished.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articlePublished.UserId);
            return View(articlePublished);
        }

        // POST: ArticlePublished/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,UserId,DateTime,IP")] ArticlePublished articlePublished)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articlePublished).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articlePublished.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articlePublished.UserId);
            return View(articlePublished);
        }

        // GET: ArticlePublished/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlePublished articlePublished = db.ArticlePublisheds.Find(id);
            if (articlePublished == null)
            {
                return HttpNotFound();
            }
            return View(articlePublished);
        }

        // POST: ArticlePublished/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticlePublished articlePublished = db.ArticlePublisheds.Find(id);
            db.ArticlePublisheds.Remove(articlePublished);
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
