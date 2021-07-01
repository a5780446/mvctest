using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvctest.Models;

namespace mvctest.Controllers
{
    public class homeController : Controller
    {
        memberEntities db = new memberEntities();
        // GET: home
        public ActionResult Index()
        {
            var x = db.product.OrderByDescending(m => m.date).ToList();
            return View(x);
        }
        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(string title,string level,DateTime date)
        {
            product z = new product();
            z.title = title;
            z.level = level;
            z.date = date;
            db.product.Add(z);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var z = db.product.Where(a => a.Id == id).FirstOrDefault();
            db.product.Remove(z);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}