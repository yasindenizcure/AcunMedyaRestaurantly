using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class AdminLayoutController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHead()
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()
        {
            ViewBag.notificationIsreadByfalseCount=db.Notifications.Where(x=>x.IsRead=="False").Count();
            var values = db.Notifications.Where(x=>x.IsRead=="False").ToList();
            return PartialView(values);
        }
        public ActionResult PartialSidebar()
        {
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
        public ActionResult PartialScript()
        {
            return PartialView();
        }
    }
}
