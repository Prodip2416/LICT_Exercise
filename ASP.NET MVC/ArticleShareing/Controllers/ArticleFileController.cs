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
    public class ArticleFileController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: ArticleFile
        public ActionResult Index()
        {
            var articleFiles = db.ArticleFiles.Include(a => a.article);
            return View(articleFiles.ToList());
        }

        // GET: ArticleFile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleFile articleFile = db.ArticleFiles.Find(id);
            if (articleFile == null)
            {
                return HttpNotFound();
            }
            return View(articleFile);
        }

        // GET: ArticleFile/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title");
            return View();
        }

        // POST: ArticleFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ArticleId,file")] ArticleFile articleFile, HttpPostedFileBase file)
        {
            articleFile.file = System.IO.Path.GetFileName(file.FileName);
            

            if (ModelState.IsValid)
            {
                db.ArticleFiles.Add(articleFile);
                db.SaveChanges();

                file.SaveAs(Server.MapPath("../uploads/articleFiles/" + articleFile.id.ToString() + articleFile.file));

                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleFile.ArticleId);
            return View(articleFile);
        }

        // GET: ArticleFile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleFile articleFile = db.ArticleFiles.Find(id);
            if (articleFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleFile.ArticleId);
            return View(articleFile);
        }

        // POST: ArticleFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ArticleId,file")] ArticleFile articleFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.articles, "id", "title", articleFile.ArticleId);
            return View(articleFile);
        }

        // GET: ArticleFile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleFile articleFile = db.ArticleFiles.Find(id);
            if (articleFile == null)
            {
                return HttpNotFound();
            }
            return View(articleFile);
        }

        // POST: ArticleFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleFile articleFile = db.ArticleFiles.Find(id);
            db.ArticleFiles.Remove(articleFile);
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
