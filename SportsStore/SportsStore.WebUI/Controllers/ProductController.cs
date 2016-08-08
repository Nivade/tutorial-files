using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;


namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository productRepository;


        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }



        public ViewResult List()
        {
            return View(productRepository.Products);
        }
    }
}