using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        
        // GET: Product

        RestaurantlyContext db = new RestaurantlyContext();
        //GET: Product

        public ActionResult ProductList()
        {
            var value = db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {

            var value = db.Products.Find(id);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var values = db.Products.Find(model.ProductId);
            values.Name = model.Name;   
            values.Description = model.Description;
            values.Price = model.Price;
            values.ImageUrl = model.ImageUrl;
            values.CategoryId = model.CategoryId;
            db.Products.Add(values);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = db.Products.Find(id);
            db.Products.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}