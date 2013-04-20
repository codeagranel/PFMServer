using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PFMServer.Models;

namespace PFMServer.Controllers.api
{
    public class ExpenseController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/Expense
        public IEnumerable<Expense> GetExpenses()
        {
            return db.Expenses.AsEnumerable();
        }

        // GET api/Expense/5
        public Expense GetExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return expense;
        }

        // PUT api/Expense/5
        public HttpResponseMessage PutExpense(int id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != expense.ExpenseId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Expense
        public HttpResponseMessage PostExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, expense);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = expense.ExpenseId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Expense/5
        public HttpResponseMessage DeleteExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Expenses.Remove(expense);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, expense);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}