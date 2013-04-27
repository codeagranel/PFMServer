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
    public class MethodsOfPaymentController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /MethodsOfPayment/

        public ActionResult Index()
        {
            return View(db.MethodsOfPayment.Where(x => x.AuthorId == WebSecurity.CurrentUserId).ToList());
        }

        //
        // GET: /MethodsOfPayment/Details/5

        public ActionResult Details(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);

            if (methodofpayment.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // GET: /MethodsOfPayment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MethodsOfPayment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MethodOfPayment methodofpayment)
        {
            if (ModelState.IsValid)
            {
                methodofpayment.AuthorId = WebSecurity.CurrentUserId;
                db.MethodsOfPayment.Add(methodofpayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(methodofpayment);
        }

        //
        // GET: /MethodsOfPayment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);

            if (methodofpayment.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // POST: /MethodsOfPayment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MethodOfPayment methodofpayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(methodofpayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(methodofpayment);
        }

        //
        // GET: /MethodsOfPayment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);

            if (methodofpayment.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // POST: /MethodsOfPayment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);

            if (methodofpayment.AuthorId != WebSecurity.CurrentUserId)
                return HttpNotFound();

            db.MethodsOfPayment.Remove(methodofpayment);
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