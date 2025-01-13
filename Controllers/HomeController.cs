using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        productContext pp = new productContext();
        public ActionResult Index()
        {
            var d = pp.categories.ToList();
            ViewBag.Categouries = new SelectList(d, "CId", "CName");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Product a)
        {
            pp.products.Add(a);
            pp.SaveChanges();
            ModelState.Clear();
            var d = pp.categories.ToList();
            ViewBag.Categouries = new SelectList(d, "CId", "CName");
            ViewBag.Message = "Product added successfully.";
            return View();
        }


        public ActionResult Addcet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addcet(Category c)
        {
          
            pp.categories.Add(c);
            pp.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public ActionResult Display(int page = 1)
        {
            int pageSize = 5;


            var products = pp.products.Include(p => p.Category)
                                       .OrderBy(p => p.PId)
                                       .Skip((page - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToList();


            var productsCount = pp.products.Count();


            int totalPages = productsCount / pageSize;
            if (productsCount % pageSize > 0)
            {
                totalPages++;
            }

            ViewBag.Products = products;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItems = productsCount;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View();
        }











    }
}