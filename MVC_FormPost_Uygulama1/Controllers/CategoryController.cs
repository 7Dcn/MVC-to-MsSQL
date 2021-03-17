using MVC_FormPost_Uygulama1.Data;
using MVC_FormPost_Uygulama1.Entities;
using MVC_FormPost_Uygulama1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FormPost_Uygulama1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            NorthwindDbContext dbContext = new NorthwindDbContext();
            var categories = (from c in dbContext.Categories
                              select new CategoryVM()
                              {
                                  CategoryID = c.CategoryID,
                                  CategoryName = c.CategoryName,
                                  Description = c.Description,
                              });

            return View(categories.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(CategoryVM vm)
        {
            NorthwindDbContext dbContext = new NorthwindDbContext();
            Category c = new Category();
            c.CategoryName = vm.CategoryName;
            c.Description = vm.Description;
            dbContext.Categories.Add(c);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            //NorthwindDbContext dbContext = new NorthwindDbContext();
            //Category c = dbContext.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);
            //dbContext.Categories.Remove(c);
            //dbContext.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult Update(CategoryVM vm)
        {
            int CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            NorthwindDbContext dbContext = new NorthwindDbContext();
            Category c = dbContext.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);
            dbContext.Categories.Remove(c);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            int CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            NorthwindDbContext dbContext = new NorthwindDbContext();
            Category c = dbContext.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);
            dbContext.Categories.Remove(c);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}