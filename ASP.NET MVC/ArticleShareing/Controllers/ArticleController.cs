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
    public class ArticleController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: Article
        public ActionResult Index()
        {
            var articles = db.articles;
            return View(articles.ToList());
        }

        public ActionResult MyArticle()
        {
            int id = (int)Session["id"];
            var articles = db.articles.Where(a=>a.UsersAuthor.UserId == id);
            return View(articles.ToList());
        }

        // GET: Article/Details/5
        public ActionResult Details(int? id, string comments = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }


            if(!string.IsNullOrEmpty(comments))
            {
                ArticleComment ac = new Models.ArticleComment();
                ac.ArticleId = Convert.ToInt32(id);
                ac.Comments = comments;
                ac.DateTime = DateTime.Now;
                ac.IP = Request.UserHostAddress;
                ac.UserId = (int)Session["id"];
                db.ArticleComments.Add(ac);
                db.SaveChanges();
            }
            return View(article);
        }

        public ActionResult Submit()
        {
            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name");
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name");
            return View();
        }

        [HttpPost, ValidateInput(false)]

        public ActionResult Submit(article article, string details = "", string video = "", HttpPostedFileBase image = null)
        {
            article.AuthorId = (int)Session["id"];
            article.dateTime = DateTime.Now;
            article.IP = Request.UserHostAddress;

            if (!string.IsNullOrEmpty(details))
            {

                if (ModelState.IsValid)
                {
                    db.articles.Add(article);
                    db.SaveChanges();
                    if (video != "")
                    {
                        ArticleVideo av = new ArticleVideo() { ArticleId = article.id, VideoLink = video };
                        db.ArticleVideos.Add(av);
                        db.SaveChanges();
                    }
                    System.IO.StreamWriter sr = new System.IO.StreamWriter(Server.MapPath("../AllArticles/" + article.title.ToLower().Trim().Replace(" ", "_") + ".html"));
                    sr.Write(details);
                    sr.Close();

                    return RedirectToAction("MyArticle");
                }
            }

            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name", article.SubscriptionTypeId);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name", article.categoryId);
            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name");
            ViewBag.id = new SelectList(db.ArticlePublisheds, "ArticleId", "IP");
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name");
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        [HttpPost, ValidateInput(false)]

        public ActionResult Create([Bind(Include = "id,title,Tags,categoryId,Description,AuthorId,dateTime,IP,SubscriptionTypeId")] article article, string details = "")
        {
            

            article.AuthorId = (int)Session["id"];
            article.dateTime = DateTime.Now;
            article.IP = Request.UserHostAddress;

            if (!string.IsNullOrEmpty(details))
            {

                if (ModelState.IsValid)
                {
                    db.articles.Add(article);
                    db.SaveChanges();

                    System.IO.StreamWriter sr = new System.IO.StreamWriter(Server.MapPath("../AllArticles/" + article.title.ToLower().Trim().Replace(" ", "_") + ".html"));
                    sr.Write(details);
                    sr.Close();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.AuthorId = new SelectList(db.UsersAuthors, "UserId", "IP", article.AuthorId);
            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name", article.SubscriptionTypeId);
            ViewBag.id = new SelectList(db.ArticlePublisheds, "ArticleId", "IP", article.id);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name", article.categoryId);
            return View(article);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.UsersAuthors, "UserId", "IP", article.AuthorId);
            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name", article.SubscriptionTypeId);
            ViewBag.id = new SelectList(db.ArticlePublisheds, "ArticleId", "IP", article.id);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name", article.categoryId);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,Tags,categoryId,Description,AuthorId,dateTime,IP,SubscriptionTypeId")] article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.UsersAuthors, "UserId", "IP", article.AuthorId);
            ViewBag.SubscriptionTypeId = new SelectList(db.SubscriptionTypes, "id", "Name", article.SubscriptionTypeId);
            ViewBag.id = new SelectList(db.ArticlePublisheds, "ArticleId", "IP", article.id);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "Name", article.categoryId);
            return View(article);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            article article = db.articles.Find(id);
            db.articles.Remove(article);
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
