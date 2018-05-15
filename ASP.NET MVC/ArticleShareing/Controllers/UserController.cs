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
    public class UserController : Controller
    {
        private bdjArticleEntities db = new bdjArticleEntities();


        public ActionResult Logout()
        {
            Session["id"] = "";
            Session["name"] = "";
            Session["type"] = "";
            Session["user"] = null;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var usr = db.Users.Where(u => u.Email.ToLower() == loginModel.Email && u.Password == loginModel.Password).First();
                if (usr == null)
                {
                    ViewBag.error = "Invalid Login";
                    return View(loginModel);
                }
                else if (usr.UsersVerified == null)
                {
                    ViewBag.error = "Please verify your account to login. To veryfy your account check your email. If you have not got any email then click <a href=\"../User/Resend?email=" + loginModel.Email + "\">here</a>";
                    return View(loginModel);
                }
                else
                {
                    Session["id"] = usr.id;
                    Session["name"] = usr.Name;
                    if (usr.UsersAdmin != null)
                    {
                        Session["type"] = "Admin";
                    }
                    else if (usr.UsersAuthor != null)
                    {
                        Session["type"] = "Author";
                    }
                    else
                    {
                        Session["type"] = "User";
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }


        // GET: User
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.City).Include(u => u.Gender).Include(u => u.UsersAdmin).Include(u => u.UsersAuthor).Include(u => u.UsersVerified);
            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "id", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase Image)
        {
            user.joinDate = DateTime.Now;
            user.IP = Request.UserHostAddress;
            user.Image = System.IO.Path.GetFileName(Image.FileName);


            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                Image.SaveAs(Server.MapPath("../uploads/userImage/" + user.id.ToString() + "_" + user.Image));

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "id", "Name", user.GenderId);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "id", "Name", user.GenderId);
            ViewBag.id = new SelectList(db.UsersAdmins, "UserId", "IP", user.id);
            ViewBag.id = new SelectList(db.UsersAuthors, "UserId", "IP", user.id);
            ViewBag.id = new SelectList(db.UsersVerifieds, "UserId", "IP", user.id);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Email,Password,Contact,Image,GenderId,dateOfBirth,joinDate,IP,Address,CityId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "id", "Name", user.CityId);
            ViewBag.GenderId = new SelectList(db.Genders, "id", "Name", user.GenderId);
            ViewBag.id = new SelectList(db.UsersAdmins, "UserId", "IP", user.id);
            ViewBag.id = new SelectList(db.UsersAuthors, "UserId", "IP", user.id);
            ViewBag.id = new SelectList(db.UsersVerifieds, "UserId", "IP", user.id);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
