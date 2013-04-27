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
    public class ExpenseTypesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /ExpenseTypes/

        public ActionResult Index()
        {
            return View(db.ExpenseTypes.Where(x => x.AuthorId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /ExpenseTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);

            if (expensetype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expensetype == null)
            {
                return HttpNotFound();
            }
            return View(expensetype);
        }

        //
        // GET: /ExpenseTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ExpenseTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseType expensetype)
        {
            if (ModelState.IsValid)
            {
                expensetype.AuthorId = WebSecurity.CurrentUserId;
                db.ExpenseTypes.Add(expensetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expensetype);
        }

        //
        // GET: /ExpenseTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);

            if (expensetype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expensetype == null)
            {
                return HttpNotFound();
            }
            return View(expensetype);
        }

        //
        // POST: /ExpenseTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseType expensetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expensetype);
        }

        //
        // GET: /ExpenseTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);

            if (expensetype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (expensetype == null)
            {
                return HttpNotFound();
            }
            return View(expensetype);
        }

        //
        // POST: /ExpenseTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);

            if (expensetype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            db.ExpenseTypes.Remove(expensetype);
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