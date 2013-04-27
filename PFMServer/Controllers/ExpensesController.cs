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
    public class ExpensesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Expenses/

        public ActionResult Index()
        {
            return View(db.Expenses.Where(x => x.AuthorId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /Expenses/Details/5

        public ActionResult Details(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);

            if (expense.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        //
        // GET: /Expenses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Expenses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.AuthorId = WebSecurity.CurrentUserId;
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        //
        // GET: /Expenses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);

            if (expense.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        //
        // POST: /Expenses/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //
        // GET: /Expenses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);

            if (expense.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        //
        // POST: /Expenses/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);

            if (expense.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            db.Expenses.Remove(expense);
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