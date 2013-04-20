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
    public class IncomeController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/Income
        public IEnumerable<Income> GetIncomes()
        {
            return db.Incomes.AsEnumerable();
        }

        // GET api/Income/5
        public Income GetIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return income;
        }

        // PUT api/Income/5
        public HttpResponseMessage PutIncome(int id, Income income)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != income.IncomeId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(income).State = EntityState.Modified;

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

        // POST api/Income
        public HttpResponseMessage PostIncome(Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, income);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = income.IncomeId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Income/5
        public HttpResponseMessage DeleteIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Incomes.Remove(income);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, income);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}