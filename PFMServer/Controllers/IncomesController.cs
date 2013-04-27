using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFMServer.Models;
using WebMatrix.WebData;
using PFMServer.Filters;

namespace PFMServer.Controllers
{
    [InitializeSimpleMembership]
    [Authorize]
    public class IncomesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Incomes/

        public ActionResult Index()
        {
            return View(db.Incomes.Where(x => x.AuthorId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /Incomes/Details/5

        public ActionResult Details(int id = 0)
        {
            Income income = db.Incomes.Find(id);
            
            if (income.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // GET: /Incomes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Incomes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Income income)
        {
            if (ModelState.IsValid)
            {
                income.AuthorId = WebSecurity.CurrentUserId;
                db.Incomes.Add(income);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        //
        // GET: /Incomes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Income income = db.Incomes.Find(id);

            if (income.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // POST: /Incomes/Edit/5

        [HttpPost]
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
        // GET: /Incomes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Income income = db.Incomes.Find(id);

            if (income.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        //
        // POST: /Incomes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Income income = db.Incomes.Find(id);

            if (income.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

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