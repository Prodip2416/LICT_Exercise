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
    public class ArticleVideoController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleVideo
        public ActionResult Index()
        {
            var articleVideos = db.ArticleVideos.Include(a => a.article);
            return View(articleVideos.ToList());
        }

        // GET: ArticleVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleVideo articleVideo = db.ArticleVideos.Find(id);
            if (articleVideo == null)
            {
                return HttpNotFound();
            }
            return View(articleVideo);
        }

        // GET: ArticleVideo/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title");
            return View();
        }

        // POST: ArticleVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ArticleId,VideoLink")] ArticleVideo articleVideo)
        {
            if (ModelState.IsValid)
            {
                db.ArticleVideos.Add(articleVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleVideo.ArticleId);
            return View(articleVideo);
        }

        // GET: ArticleVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleVideo articleVideo = db.ArticleVideos.Find(id);
            if (articleVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleVideo.ArticleId);
            return View(articleVideo);
        }

        // POST: ArticleVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ArticleId,VideoLink")] ArticleVideo articleVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleVideo.ArticleId);
            return View(articleVideo);
        }

        // GET: ArticleVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleVideo articleVideo = db.ArticleVideos.Find(id);
            if (articleVideo == null)
            {
                return HttpNotFound();
            }
            return View(articleVideo);
        }

        // POST: ArticleVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleVideo articleVideo = db.ArticleVideos.Find(id);
            db.ArticleVideos.Remove(articleVideo);
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
