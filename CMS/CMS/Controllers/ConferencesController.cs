using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.Repositories.Entities;
using CMS.Services.Entities;
using CMS.ViewModels;
using CMS.ViewModels.ConferenceViewModels;

namespace CMS.Controllers
{
    public class ConferencesController : Controller
    {
        // THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
        // how things work there

        // There might not be a use for all the views/methods that were automatically generated

        private readonly ConferenceService ConferenceService;

        public ConferencesController()
        {
            ConferenceService = new ConferenceService(new ConferenceRepository());
        }

        //private DatabaseContext db = new DatabaseContext();

        // GET: Conferences
        public ActionResult Index()
        {
            return View(ConferenceService.FindAll());
        }
        /*
        // GET: Conferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }
        */

        // GET: Conferences/Create
        public ActionResult Create()
        {
            
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            /*
            CreateConferenceViewModel model = new CreateConferenceViewModel();
            return View(model.CheckEntity(ConferenceService,entity));
            */

            CreateConferenceViewModel model = new CreateConferenceViewModel();
            return View(model);

        }

        public ActionResult Delete()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            DeleteConferenceViewModel model = new DeleteConferenceViewModel();
            return View(model);
        }

        // POST: Conferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,Location")] Conference conference)
        {
            try
            {
                CreateConferenceViewModel model = new CreateConferenceViewModel(ModelState.IsValid, conference, ConferenceService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete( Conference conference)
        {
            try
            {
                DeleteConferenceViewModel model = new DeleteConferenceViewModel(ModelState.IsValid, conference, ConferenceService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }
        /*
        // GET: Conferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }

        // POST: Conferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,Location")] Conference conference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conference);
        }

        // GET: Conferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }

        // POST: Conferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conference conference = db.Conferences.Find(id);
            db.Conferences.Remove(conference);
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
    */
    }
}
