using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead() 
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = db.Adresses.Select(x => x.Call).FirstOrDefault();
            ViewBag.OpenHours = db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature() 
        {
            ViewBag.SubTitle = db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title = db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = db.Features.Select(x => x.VideoUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var value = db.Services.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialMenu()
        {
            var value = db.Products.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model) 
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            db.Contacts.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Mesajınız başarıyla alındı.";
            return View("Index");
        }
        public PartialViewResult PartialSpecial()
        {
            var value = db.Specials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialTestimonial()
        {
            var value = db.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialChef()
        {
            var value = db.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialBookATable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookATableAdd(BookATable model)
        {
            model.IsRead = false;
            db.BookATables.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Mesajınız başarıyla alındı.";
            return View("Index");
        }
        public PartialViewResult PartialAdress()
        {
            ViewBag.Location = db.Adresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.Call = db.Adresses.Select(x => x.Call).FirstOrDefault();
            ViewBag.Email = db.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.OpenHours = db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }

    }
}