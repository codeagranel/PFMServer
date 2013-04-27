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
    public class MethodsOfPaymentController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/MethodsOfPayment
        public IEnumerable<MethodOfPayment> GetMethodOfPayments()
        {
            return db.MethodsOfPayment.AsEnumerable();
        }

        // GET api/MethodsOfPayment/5
        public MethodOfPayment GetMethodOfPayment(int id)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);
            if (methodofpayment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return methodofpayment;
        }

        // PUT api/MethodsOfPayment/5
        public HttpResponseMessage PutMethodOfPayment(int id, MethodOfPayment methodofpayment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != methodofpayment.MethodOfPaymentId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(methodofpayment).State = EntityState.Modified;

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

        // POST api/MethodsOfPayment
        public HttpResponseMessage PostMethodOfPayment(MethodOfPayment methodofpayment)
        {
            if (ModelState.IsValid)
            {
                db.MethodsOfPayment.Add(methodofpayment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, methodofpayment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = methodofpayment.MethodOfPaymentId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/MethodsOfPayment/5
        public HttpResponseMessage DeleteMethodOfPayment(int id)
        {
            MethodOfPayment methodofpayment = db.MethodsOfPayment.Find(id);
            if (methodofpayment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.MethodsOfPayment.Remove(methodofpayment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, methodofpayment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}