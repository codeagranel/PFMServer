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
    public class MethodOfPaymentController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /MethodOfPayment/

        [Authorize]
        public ActionResult Index()
        {
            return View(db.MethodOfPayments.ToList());
        }

        //
        // GET: /MethodOfPayment/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodOfPayments.Find(id);
            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // GET: /MethodOfPayment/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MethodOfPayment/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MethodOfPayment methodofpayment)
        {
            if (ModelState.IsValid)
            {
                db.MethodOfPayments.Add(methodofpayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(methodofpayment);
        }

        //
        // GET: /MethodOfPayment/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodOfPayments.Find(id);
            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // POST: /MethodOfPayment/Edit/5

        [HttpPost]
        [Authorize]
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
        // GET: /MethodOfPayment/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            MethodOfPayment methodofpayment = db.MethodOfPayments.Find(id);
            if (methodofpayment == null)
            {
                return HttpNotFound();
            }
            return View(methodofpayment);
        }

        //
        // POST: /MethodOfPayment/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MethodOfPayment methodofpayment = db.MethodOfPayments.Find(id);
            db.MethodOfPayments.Remove(methodofpayment);
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