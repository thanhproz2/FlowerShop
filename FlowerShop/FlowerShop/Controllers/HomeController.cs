using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class HomeController : Controller
    {
        FlowerShopEntities db = new FlowerShopEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.fPro = db.Products.Where(p => p.status == true).ToList();
            ViewBag.nPro = db.Products.Where(p => p.specials == true).ToList();
            return View();
        }
    }
}