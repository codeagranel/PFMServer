using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFMServer.Models;

namespace PFMServer.Controllers
{
    public class IncomeController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Income/

        [Authorize]
        public ActionResult Index()
        {
            try
            {
                return View(db.Incomes.ToList());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Message :" + ex.Message + " StackTrace: " + ex.StackTrace);
                return View();
            }
        }

        //
        // GET: /Income/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // GET: /Income/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Income/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        //
        // GET: /Income/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // POST: /Income/Edit/5

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Income income)
        {
            if (ModelState.IsValid)
            {
                db.Entry(income).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(income);
        }

        //
        // GET: /Income/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // POST: /Income/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Income income = db.Incomes.Find(id);
            db.Incomes.Remove(income);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}