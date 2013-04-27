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
    public class IncomeTypesController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/IncomeTypes
        public IEnumerable<IncomeType> GetIncomeTypes()
        {
            return db.IncomeTypes.AsEnumerable();
        }

        // GET api/IncomeTypes/5
        public IncomeType GetIncomeType(int id)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);
            if (incometype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return incometype;
        }

        // PUT api/IncomeTypes/5
        public HttpResponseMessage PutIncomeType(int id, IncomeType incometype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != incometype.IncomeTypeId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(incometype).State = EntityState.Modified;

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

        // POST api/IncomeTypes
        public HttpResponseMessage PostIncomeType(IncomeType incometype)
        {
            if (ModelState.IsValid)
            {
                db.IncomeTypes.Add(incometype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, incometype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = incometype.IncomeTypeId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/IncomeTypes/5
        public HttpResponseMessage DeleteIncomeType(int id)
        {
            IncomeType incometype = db.IncomeTypes.Find(id);
            if (incometype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.IncomeTypes.Remove(incometype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, incometype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}