using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIVO.Models;

namespace VIVO.Controllers
{
    public class HomeController : Controller
    {
            private Database1Entities db = new Database1Entities(); 
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductType);
            return View(products.ToList());
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