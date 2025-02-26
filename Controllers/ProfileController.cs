using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Session["id"] == null) 
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["id"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            if (value.Password != p.Password) 
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz Şifre Yanlış.");
                return View(value);
            }
            if (p.ImageFile != null) 
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                var saveLocation = currentDirectory + "images\\";

                var fileName = Path.Combine(saveLocation,p.ImageFile.FileName);

                p.ImageFile.SaveAs(fileName);

                value.ImageUrl = "/images/" + p.ImageFile.FileName;
            }
            value.UserName = p.UserName;
            value.Password = p.Password;
            value.Email = p.Email;
            value.Name = p.Name;
            value.Surname = p.Surname;
            db.SaveChanges();
            return RedirectToAction("Index","Dashboard");
        }
        [HttpGet]
        public ActionResult ChangePassword() 
        {
            if (Session["id"] == null) 
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Admin p)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["id"]);
            if (p.CurrentPassword != value.Password) 
            {
                ModelState.AddModelError("", "Mevcut Şifre Hatalı.");
                return View(p);
            }

            if (p.NewPassword != p.ConfirmPassword) 
            {
                ModelState.AddModelError("", "Yeni Şifreler Eşleşmiyor.");
                return View(p);
            }

            value.Password = p.NewPassword;
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
            
        }

    }
}