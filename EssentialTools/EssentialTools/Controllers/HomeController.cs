using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;


namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {

        private Product[] products =
        {
            new Product
            {
                Name = "Kayak",
                Category = "Watersports",
                Price = 275m
            },
            new Product
            {
                Name = "Lifejacket",
                Category = "Watersports",
                Price = 48.95m
            },
            new Product
            {
                Name = "Soccer ball",
                Category = "Soccer",
                Price = 19.50m
            },
            new Product
            {
                Name = "Corner flag",
                Category = "Soccer",
                Price = 34.95m
            },
        };

        // GET: Home
        public ActionResult Index()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calc) {Products = products};

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}