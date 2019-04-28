using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class ComiteesController : Controller
    {

        // THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
        // how things work there

        // There might not be a use for all the views/methods that were automatically generated
        private DatabaseContext db = new DatabaseContext();

        // GET: Comitees
        public ActionResult Index()
        {
            return View(db.Comitees.ToList());
        }

        // GET: Comitees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comitee comitee = db.Comitees.Find(id);
            if (comitee == null)
            {
                return HttpNotFound();
            }
            return View(comitee);
        }

        // GET: Comitees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comitees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Comitee comitee)
        {
            if (ModelState.IsValid)
            {
                db.Comitees.Add(comitee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comitee);
        }

        // GET: Comitees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comitee comitee = db.Comitees.Find(id);
            if (comitee == null)
            {
                return HttpNotFound();
            }
            return View(comitee);
        }

        // POST: Comitees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Comitee comitee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comitee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comitee);
        }

        // GET: Comitees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comitee comitee = db.Comitees.Find(id);
            if (comitee == null)
            {
                return HttpNotFound();
            }
            return View(comitee);
        }

        // POST: Comitees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comitee comitee = db.Comitees.Find(id);
            db.Comitees.Remove(comitee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
