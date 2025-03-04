using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Events.ToList();
            return View(value);
        }
        public ActionResult EventList(string searchText)
        {
            List<Event> values;
            if (searchText != null)
            {
                values = db.Events.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }
            var value = db.Events.ToList();
            return View(value);
        }
        public ActionResult EventCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventCreate(Event model)
        {
            db.Events.Add(model);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        [HttpGet]
        public ActionResult EventEdit(int id)
        {
            var value = db.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EventEdit(Event model)
        {
            var value = db.Events.Find(model.EventId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.Price = model.Price;
            value.Message = model.Message;
            value.Message2 = model.Message2;
            value.Message3 = model.Message3;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        public ActionResult EventDelete(int id)
        {
            var value = db.Events.Find(id);
            db.Events.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
    }
}