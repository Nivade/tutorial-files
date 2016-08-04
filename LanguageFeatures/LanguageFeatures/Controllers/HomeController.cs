using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;


namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to an URL to show an example";
        }



        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();

            myProduct.Name = "Kayak";

            string productName = myProduct.Name;

            return View("Result", (object) $"Product name: {productName}");
        }



        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275m,
                Category = "Watersports"
            };

            return View("Result", (object)$"Category: {myProduct.Category}");
        }



        public ViewResult CreateCollection()
        {
            string[] stringArray =
            {
                "apple", "orange", "plum"
            };

            List<int> intList = new List<int> { 10, 20, 30, 40};

            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                {"apple", 10},
                {"orange", 20 },
                {"plum", 30 }
            };

            return View("Result", (object) stringArray[1]);
        }



        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Kayak",
                        Price = 275m
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner flag",
                        Price = 34.95m
                    }
                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object) $"Total: {cartTotal}");
        }
    }
}