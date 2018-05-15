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
    public class ArticleCommentController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleComment
        public ActionResult Index()
        {
            var articleComments = db.ArticleComments.Include(a => a.article).Include(a => a.User);
            return View(articleComments.ToList());
        }

        // GET: ArticleComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articleComment = db.ArticleComments.Find(id);
            if (articleComment == null)
            {
                return HttpNotFound();
            }
            return View(articleComment);
        }

        // GET: ArticleComment/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.vwArticlePublisheds, "id", "title");
            ViewBag.UserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: ArticleComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleComment articleComment)
        {
            articleComment.DateTime = DateTime.Now;
            articleComment.IP = Request.UserHostAddress;
            articleComment.UserId = (int)Session["id"];

            if (ModelState.IsValid)
            {
                db.ArticleComments.Add(articleComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.vwArticlePublisheds, "id", "title", articleComment.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleComment.UserId);
            return View(articleComment);
        }

        // GET: ArticleComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articleComment = db.ArticleComments.Find(id);
            if (articleComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleComment.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleComment.UserId);
            return View(articleComment);
        }

        // POST: ArticleComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArticleId,Comments,DateTime,UserId,IP")] ArticleComment articleComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleComment.ArticleId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Name", articleComment.UserId);
            return View(articleComment);
        }

        // GET: ArticleComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articleComment = db.ArticleComments.Find(id);
            if (articleComment == null)
            {
                return HttpNotFound();
            }
            return View(articleComment);
        }

        // POST: ArticleComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleComment articleComment = db.ArticleComments.Find(id);
            db.ArticleComments.Remove(articleComment);
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
