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
    public class ReservationController : Controller
    {
            RestaurantlyContext db = new RestaurantlyContext();
            public ActionResult Index()
            {
                var values = db.Reservations.ToList();
                return View(values);
            }

            public ActionResult ApproveReservation(int id)
            {
                var values = db.Reservations.Find(id);
                values.ReservationStatus = "Onaylandı";
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }

            public ActionResult HoldReservation(int id)
            {
                var values = db.Reservations.Find(id);
                values.ReservationStatus = "Beklemede";
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            public ActionResult RejectReservation(int id)
            {
                var values = db.Reservations.Find(id);
                values.ReservationStatus = "Reddedildi";
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
        public ActionResult ReservationList(string searchText)
        {
            List<Reservation> values;
            if (searchText != null)
            {
                values = db.Reservations.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }
            var value = db.Reservations.ToList();
            return View(value);
        }
        public ActionResult ReservationCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReservationCreate(Reservation model)
        {
            db.Reservations.Add(model);
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            var value = db.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ReservationEdit(Reservation model)
        {
            var value = db.Reservations.Find(model.ReservationId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Phone = model.Phone;
            value.Description = model.Description;
            value.ReservationDate = model.ReservationDate;
            value.Time = model.Time;
            value.GuestCount = model.GuestCount;
            value.ReservationStatus = model.ReservationStatus;
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationDelete(int id)
        {
            var value = db.Reservations.Find(id);
            db.Reservations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}
