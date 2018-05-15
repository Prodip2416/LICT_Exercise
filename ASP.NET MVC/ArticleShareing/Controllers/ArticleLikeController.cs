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
    public class ArticleLikeController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleLike
        public ActionResult Index()
        {
            var articleLikes = db.ArticleLikes.Include(a => a.article).Include(a => a.User);
            return View(articleLikes.ToList());
        }

        // GET: ArticleLike/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLike articleLike = db.ArticleLikes.Find(id);
            if (articleLike == null)
            {
                return HttpNotFound();
            }
            return View(articleLike);
        }

        // GET: ArticleLike/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title");
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: ArticleLike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ArticleId,DateTime,UserId,IP")] ArticleLike articleLike)
        {
            if (ModelState.IsValid)
            {
                db.ArticleLikes.Add(articleLike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLike.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleLike.UserId);
            return View(articleLike);
        }

        // GET: ArticleLike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLike articleLike = db.ArticleLikes.Find(id);
            if (articleLike == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLike.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleLike.UserId);
            return View(articleLike);
        }

        // POST: ArticleLike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ArticleId,DateTime,UserId,IP")] ArticleLike articleLike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleLike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleLike.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleLike.UserId);
            return View(articleLike);
        }

        // GET: ArticleLike/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleLike articleLike = db.ArticleLikes.Find(id);
            if (articleLike == null)
            {
                return HttpNotFound();
            }
            return View(articleLike);
        }

        // POST: ArticleLike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleLike articleLike = db.ArticleLikes.Find(id);
            db.ArticleLikes.Remove(articleLike);
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
