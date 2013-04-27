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
    public class ExpenseTypesController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/ExpenseTypes
        public IEnumerable<ExpenseType> GetExpenseTypes()
        {
            return db.ExpenseTypes.AsEnumerable();
        }

        // GET api/ExpenseTypes/5
        public ExpenseType GetExpenseType(int id)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);
            if (expensetype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return expensetype;
        }

        // PUT api/ExpenseTypes/5
        public HttpResponseMessage PutExpenseType(int id, ExpenseType expensetype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != expensetype.ExpenseTypeId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(expensetype).State = EntityState.Modified;

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

        // POST api/ExpenseTypes
        public HttpResponseMessage PostExpenseType(ExpenseType expensetype)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseTypes.Add(expensetype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, expensetype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = expensetype.ExpenseTypeId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ExpenseTypes/5
        public HttpResponseMessage DeleteExpenseType(int id)
        {
            ExpenseType expensetype = db.ExpenseTypes.Find(id);
            if (expensetype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ExpenseTypes.Remove(expensetype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, expensetype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}