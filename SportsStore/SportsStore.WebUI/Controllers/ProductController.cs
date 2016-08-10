using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;


namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository productRepository;
        public int PageSize = 4;


        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }



        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productRepository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? productRepository.Products.Count() : productRepository.Products.Count(x => x.Category == category)
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}