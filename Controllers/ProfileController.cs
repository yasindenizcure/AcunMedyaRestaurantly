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
    public class ProfileController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            var value = db.Admins.Find(Session["id"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            value.UserName = p.UserName;
            value.Password = p.Password;
            value.Email = p.Email;
            value.Name = p.Name;
            value.ImageUrl = p.ImageUrl;
            value.Surname = p.Surname;
            db.SaveChanges();
            return RedirectToAction("Index","Profile");
        }
    }
}