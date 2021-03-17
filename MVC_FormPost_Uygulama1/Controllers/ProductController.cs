using MVC_FormPost_Uygulama1.Data;
using MVC_FormPost_Uygulama1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FormPost_Uygulama1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            NorthwindDbContext dbContext = new NorthwindDbContext();

            var id = Request.QueryString["CategoryID"];
            int CategoryID = Convert.ToInt32(id);

            var products = (from p in dbContext.Products
                            where p.CategoryID == CategoryID
                            select new ProductVM()
                            {
                                CategoryID = p.CategoryID,
                                ProductName = p.ProductName,
                                ProductID = p.ProductID,
                                SupplierID = p.SupplierID,
                                UnitPrice = p.UnitPrice
                            });

            return View(products.ToList());
        }
    }
}