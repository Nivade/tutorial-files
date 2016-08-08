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

        private IProductsRepository productsRepository;


        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }



        public ViewResult List()
        {
            return View(productsRepository.Products);
        }
    }
}