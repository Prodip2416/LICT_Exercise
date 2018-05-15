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
    public class LiveMessageController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();

        // GET: LiveMessage
        public ActionResult Index()
        {
            var liveMessages = db.LiveMessages.Include(l => l.User).Include(l => l.User1);
            return View(liveMessages.ToList());
        }

        public ActionResult MyMessage()
        {
            ViewBag.userId = db.Users.Where(u => u.UsersVerified != null);

            int id = (int)Session["id"];


            return View(db.LiveMessages.Where(lm=>lm.SenderUserId == id || lm.ReceiverUserId == id).ToList());
        }

        // GET: LiveMessage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveMessage liveMessage = db.LiveMessages.Find(id);
            if (liveMessage == null)
            {
                return HttpNotFound();
            }
            return View(liveMessage);
        }

        // GET: LiveMessage/Create
        public ActionResult Create()
        {
            ViewBag.ReceiverUserId = new SelectList(db.Users, "id", "Name");
            return View();
        }

        // POST: LiveMessage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,SenderUserId,ReceiverUserId,DateTime,IP,Message,SeenTime")] LiveMessage liveMessage)
        {
            liveMessage.DateTime = DateTime.Now;
            liveMessage.IP = Request.UserHostAddress;
            liveMessage.SeenTime = null;
            liveMessage.SenderUserId = (int)Session["id"];

            if (ModelState.IsValid)
            {
                db.LiveMessages.Add(liveMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiverUserId = new SelectList(db.Users, "id", "Name", liveMessage.ReceiverUserId);
            return View(liveMessage);
        }

        // GET: LiveMessage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveMessage liveMessage = db.LiveMessages.Find(id);
            if (liveMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceiverUserId = new SelectList(db.Users, "id", "Name", liveMessage.ReceiverUserId);
            ViewBag.SenderUserId = new SelectList(db.Users, "id", "Name", liveMessage.SenderUserId);
            return View(liveMessage);
        }

        // POST: LiveMessage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SenderUserId,ReceiverUserId,DateTime,IP,Message,SeenTime")] LiveMessage liveMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liveMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceiverUserId = new SelectList(db.Users, "id", "Name", liveMessage.ReceiverUserId);
            ViewBag.SenderUserId = new SelectList(db.Users, "id", "Name", liveMessage.SenderUserId);
            return View(liveMessage);
        }

        // GET: LiveMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveMessage liveMessage = db.LiveMessages.Find(id);
            if (liveMessage == null)
            {
                return HttpNotFound();
            }
            return View(liveMessage);
        }

        // POST: LiveMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LiveMessage liveMessage = db.LiveMessages.Find(id);
            db.LiveMessages.Remove(liveMessage);
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
