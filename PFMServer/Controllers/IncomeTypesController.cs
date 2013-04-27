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
    public class IncomeTypesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /IncomeTypes/

        public ActionResult Index()
        {
            return View(db.IncomeTypes.Where(x => x.AuthorId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /IncomeTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);

            if (incometype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (incometype == null)
            {
                return HttpNotFound();
            }
            return View(incometype);
        }

        //
        // GET: /IncomeTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IncomeTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeType incometype)
        {
            if (ModelState.IsValid)
            {
                incometype.AuthorId = WebSecurity.CurrentUserId;
                db.IncomeTypes.Add(incometype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incometype);
        }

        //
        // GET: /IncomeTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);

            if (incometype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (incometype == null)
            {
                return HttpNotFound();
            }
            return View(incometype);
        }

        //
        // POST: /IncomeTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeType incometype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incometype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incometype);
        }

        //
        // GET: /IncomeTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);

            if (incometype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (incometype == null)
            {
                return HttpNotFound();
            }
            return View(incometype);
        }

        //
        // POST: /IncomeTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);

            if (incometype.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            db.IncomeTypes.Remove(incometype);
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