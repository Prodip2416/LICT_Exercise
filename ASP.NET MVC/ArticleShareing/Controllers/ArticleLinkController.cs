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
    public class ArticleLinkController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleLink
        public ActionResult Index()
        {
            var articleLinks = db.ArticleLinks.Include(a => a.article);
            return View(articleLinks.ToList());
        }

        // GET: ArticleLink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLink articleLink = db.ArticleLinks.Find(id);
            if (articleLink == null)
            {
                return HttpNotFound();
            }
            return View(articleLink);
        }

        // GET: ArticleLink/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title");
            return View();
        }

        // POST: ArticleLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ArticleId,Link")] ArticleLink articleLink)
        {
            if (ModelState.IsValid)
            {
                db.ArticleLinks.Add(articleLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLink.ArticleId);
            return View(articleLink);
        }

        // GET: ArticleLink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLink articleLink = db.ArticleLinks.Find(id);
            if (articleLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLink.ArticleId);
            return View(articleLink);
        }

        // POST: ArticleLink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ArticleId,Link")] ArticleLink articleLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLink.ArticleId);
            return View(articleLink);
        }

        // GET: ArticleLink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLink articleLink = db.ArticleLinks.Find(id);
            if (articleLink == null)
            {
                return HttpNotFound();
            }
            return View(articleLink);
        }

        // POST: ArticleLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleLink articleLink = db.ArticleLinks.Find(id);
            db.ArticleLinks.Remove(articleLink);
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
