using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDJArticle15.Controllers
{
    public class HomeController : Controller
    {

        BDJArticle15.Models.bdjArticleEntities db = new Models.bdjArticleEntities();

        public ActionResult Index()
        {
            
            var v = db.articles.Where(a=>a.ArticlePublished != null);
            return View(v.ToList());
        }

        public ActionResult AdminIndex()
        {

           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}