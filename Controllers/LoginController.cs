using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedyaRestaurantly.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = db.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password == p.Password);
            if (values != null) 
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["a"]=values.UserName;
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
    }
}