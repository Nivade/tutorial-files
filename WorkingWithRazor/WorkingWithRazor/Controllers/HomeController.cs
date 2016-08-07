using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkingWithRazor.Models;


namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {

        private Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275m
        };

        // GET: Home
        public ActionResult Index()
        {
            return View(myProduct);
        }



        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }



        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = true;
            ViewBag.Supplier = null;

            return View(myProduct);
        }
    }
}