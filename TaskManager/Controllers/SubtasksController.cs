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
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class SubtasksController : ApiController
    {
        private TaskManagerContext db = new TaskManagerContext();

        // GET api/Subtasks
        public IEnumerable<Subtask> GetSubtasks()
        {
            return db.Subtasks.AsEnumerable();
        }

        // GET api/Subtasks/5
        public Subtask GetSubtask(int id)
        {
            Subtask subtask = db.Subtasks.Find(id);
            if (subtask == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return subtask;
        }

        // PUT api/Subtasks/5
        public HttpResponseMessage PutSubtask(int id, Subtask subtask)
        {
            if (ModelState.IsValid && id == subtask.Id)
            {
                db.Entry(subtask).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Subtasks
        public HttpResponseMessage PostSubtask(Subtask subtask)
        {
            if (ModelState.IsValid)
            {
                db.Subtasks.Add(subtask);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subtask);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subtask.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Subtasks/5
        public HttpResponseMessage DeleteSubtask(int id)
        {
            Subtask subtask = db.Subtasks.Find(id);
            if (subtask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Subtasks.Remove(subtask);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subtask);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}