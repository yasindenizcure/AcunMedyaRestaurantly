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
    public class BookATableController : Controller
    {

            // GET: BookATable
            RestaurantlyContext db = new RestaurantlyContext();
            public ActionResult Index()
            {
                var value = db.BookATables.ToList();
                return View(value);
            }
            public ActionResult BookATableList(string searchText)
            {
                List<BookATable> values;
                if (searchText != null)
                {
                    values = db.BookATables.Where(x => x.Name.Contains(searchText)).ToList();
                    return View(values);
                }
                var value = db.BookATables.ToList();
                return View(value);
            }
            public ActionResult BookATableCreate()
            {
                return View();
            }
            [HttpPost]
            public ActionResult BookATableCreate(BookATable model)
            {
                db.BookATables.Add(model);
                db.SaveChanges();
                return RedirectToAction("BookATableList");
            }
            [HttpGet]
            public ActionResult BookATableEdit(int id)
            {
                var value = db.BookATables.Find(id);
                return View(value);
            }
            [HttpPost]
            public ActionResult BookATableEdit(BookATable model)
            {
                var value = db.BookATables.Find(model.BookATableId);
                value.Name = model.Name;
                value.Email = model.Email;
                value.Phone = model.Phone;
                value.IsRead = model.IsRead;
                value.SendDate = model.SendDate;
                value.People = model.People;
                value.Message = model.Message;
                db.SaveChanges();
                return RedirectToAction("BookATableList");
            }
            public ActionResult BookATableDelete(int id)
            {
                var value = db.BookATables.Find(id);
                db.BookATables.Remove(value);
                db.SaveChanges();
                return RedirectToAction("BookATableList");
            }
        }
    }