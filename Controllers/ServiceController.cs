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
    public class ServiceController : Controller
    {
        // GET: About
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Services.ToList();
            return View(value);
        }
        public ActionResult ServiceList(string searchText)
        {
            List<Service> values;
            if (searchText != null)
            {
                values = db.Services.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }
            var value = db.Services.ToList();
            return View(value);
        }
        public ActionResult ServiceCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ServiceCreate(Service model)
        {
            db.Services.Add(model);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult ServiceEdit(int id)
        {
            var value = db.Services.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ServiceEdit(Service model)
        {
            var value = db.Services.Find(model.ServiceId);
            value.Title = model.Title;
            value.Description = model.Description;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult ServiceDelete(int id)
        {
            var value = db.Services.Find(id);
            db.Services.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}