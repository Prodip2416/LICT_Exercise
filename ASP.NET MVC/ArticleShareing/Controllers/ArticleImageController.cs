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
    public class ArticleImageController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleImage
        public ActionResult Index()
        {
            var articleImages = db.ArticleImages.Include(a => a.article);
            return View(articleImages.ToList());
        }

        // GET: ArticleImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleImage articleImage = db.ArticleImages.Find(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            return View(articleImage);
        }

        // GET: ArticleImage/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title");
            return View();
        }

        // POST: ArticleImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ArticleId,Image,title")] ArticleImage articleImage, HttpPostedFileBase Image)
        {
            articleImage.Image = System.IO.Path.GetFileName(Image.FileName);

            if (ModelState.IsValid)
            {
                db.ArticleImages.Add(articleImage);
                db.SaveChanges();
                Image.SaveAs(Server.MapPath ("../uploads/articleImages/" + articleImage.id.ToString() + "_"+ articleImage.Image));
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleImage.ArticleId);
            return View(articleImage);
        }

        // GET: ArticleImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleImage articleImage = db.ArticleImages.Find(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleImage.ArticleId);
            return View(articleImage);
        }

        // POST: ArticleImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ArticleId,Image,title")] ArticleImage articleImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleImage.ArticleId);
            return View(articleImage);
        }

        // GET: ArticleImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleImage articleImage = db.ArticleImages.Find(id);
            if (articleImage == null)
            {
                return HttpNotFound();
            }
            return View(articleImage);
        }

        // POST: ArticleImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleImage articleImage = db.ArticleImages.Find(id);
            db.ArticleImages.Remove(articleImage);
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
