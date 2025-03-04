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
    public class ContactController : Controller
    {
        // GET: Contact
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Contacts.ToList();
            return View(value);
        }
        public ActionResult ContactList(string searchText)
        {
            List<Contact> values;
            if (searchText != null)
            {
                values = db.Contacts.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }
            var value = db.Contacts.ToList();
            return View(value);
        }
        public ActionResult ContactCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactCreate(Contact model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult ContactEdit(int id)
        {
            var value = db.Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ContactEdit(Contact model)
        {
            var value = db.Contacts.Find(model.ContactId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Subject = model.Subject;
            value.IsRead = model.IsRead;
            value.SendDate = model.SendDate;
            value.Message = model.Message;
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult ContactDelete(int id)
        {
            var value = db.Contacts.Find(id);
            db.Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}