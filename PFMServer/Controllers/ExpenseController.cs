using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFMServer.Models;
using WebMatrix.WebData;

namespace PFMServer.Controllers
{
    public class ExpenseController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Expense/

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Expenses.Where(x => x.UserId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /Expense/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        //
        // GET: /Expense/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.Where(x => x.UserId == WebSecurity.CurrentUserId).ToList();
            ViewBag.MethodsOfPayment = db.MethodOfPayments.Where(x => x.UserId == WebSecurity.CurrentUserId).ToList();
            return View();
        }

        //
        // POST: /Expense/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.UserId = WebSecurity.CurrentUserId;
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        //
        // GET: /Expense/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Categories = db.Categories.Where(x => x.UserId == WebSecurity.CurrentUserId).ToList();
            ViewBag.MethodsOfPayment = db.MethodOfPayments.Where(x => x.UserId == WebSecurity.CurrentUserId).ToList();
            return View(expense);
        }

        //
        // POST: /Expense/Edit/5

        [HttpPost]
        [Authorize]
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
        // GET: /Expense/Delete/5
        
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        //
        // POST: /Expense/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
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