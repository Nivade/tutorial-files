﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;


namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanPaginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product
                {
                    ProductID = 1,
                    Name = "P1"
                },
                new Product
                {
                    ProductID = 2,
                    Name = "P2"
                },
                new Product
                {
                    ProductID = 3,
                    Name = "P3"
                },
                new Product
                {
                    ProductID = 4,
                    Name = "P4"
                },
                new Product
                {
                    ProductID = 5,
                    Name = "P5"
                },
            });

            ProductController controller = new ProductController(mock.Object);

            controller.PageSize = 3;

            ProductListViewModel result = (ProductListViewModel) controller.List(null, 2).Model;

            Product[] prodArray = result.Products.ToArray();

            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }



        [TestMethod]
        public void CanGeneratePageLinks()
        {
            // Arrange - define an HTML helper
            // We need to do this in order to apply the extension method.
            HtmlHelper myHelper = null;

            // Arrange - create PagingInfo data.
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - setup the delegate using a lambda expression.
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                          + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                          + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }


        [TestMethod]
        public void CanSendPaginationViewModel()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product
                {
                    ProductID = 1,
                    Name = "P1"
                },
                new Product
                {
                    ProductID = 2,
                    Name = "P2"
                },
                new Product
                {
                    ProductID = 3,
                    Name = "P3"
                },
                new Product
                {
                    ProductID = 4,
                    Name = "P4"
                },
                new Product
                {
                    ProductID = 5,
                    Name = "P5"
                },
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel result = (ProductListViewModel) controller.List(null, 2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }



        [TestMethod]
        public void CanFilterProducts()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product
                {
                    ProductID = 1,
                    Name = "P1",
                    Category = "Cat1"
                },
                new Product
                {
                    ProductID = 2,
                    Name = "P2",
                    Category = "Cat2"
                },
                new Product
                {
                    ProductID = 3,
                    Name = "P3",
                    Category = "Cat1"
                },
                new Product
                {
                    ProductID = 4,
                    Name = "P4",
                    Category = "Cat2"
                },
                new Product
                {
                    ProductID = 5,
                    Name = "P5",
                    Category = "Cat3"
                },
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            Product[] result = ((ProductListViewModel) controller.List("Cat2", 1).Model).Products.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
    }
}
