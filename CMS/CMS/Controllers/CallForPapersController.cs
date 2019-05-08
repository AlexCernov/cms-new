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
    public class CallForPapersController : Controller
    {

        // THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
        // how things work there

        // There might not be a use for all the views/methods that were automatically generated



        private DatabaseContext db = new DatabaseContext();

		[HttpPost]
		public string Index(FormCollection fc, string searchString)
		{
			return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
		}

		// GET: CallForPapers
		public ActionResult Index(string callsForPapersAcronym,string searchString)
        {
			var AcronymList = new List<string>();

			var AcronymQry = from a in db.CallsForPapers orderby a.Acronym select a.Acronym;

			AcronymList.AddRange(AcronymQry.Distinct());
			ViewBag.callsForPapersAcronym = new SelectList(AcronymList);

			var callsforpapers = from c in db.CallsForPapers select c;
			Console.Write(callsforpapers.ToList());

			if (!String.IsNullOrEmpty(searchString))
			{
				callsforpapers = callsforpapers.Where(s => s.Name.Contains(searchString));
			}

			if (!String.IsNullOrEmpty(callsForPapersAcronym))
			{
				callsforpapers = callsforpapers.Where(x => x.Acronym == callsForPapersAcronym);
			}
			//View(db.CallsForPapers.ToList());
			return View(callsforpapers.ToList());
		}

        // GET: CallForPapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallForPapers callForPapers = db.CallsForPapers.Find(id);
            if (callForPapers == null)
            {
                return HttpNotFound();
            }
            return View(callForPapers);
        }


		// GET: CallForPapers/Create
		public ActionResult Create()
		{
			var topics = db.Topics.Select(t => t.Id);
			var viewModel = new CallForPapers
			{
				SelectTopic = new SelectList(topics)
			};	
			return View(viewModel);
        }

        // POST: CallForPapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Acronym,Name,StartDate,DeadlineAbstract,DeadlineProposal,Topic_Id1,Topic_Name")] CallForPapers callForPapers)
        {
            if (ModelState.IsValid)
            {
				var topicName = from c in db.Topics where c.Id == callForPapers.Topic_Id1 select c.Name ;
				callForPapers.Topic_Name = topicName.Single();
				db.CallsForPapers.Add(callForPapers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(callForPapers);
        }

		// GET: CallForPapers/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallForPapers callForPapers = db.CallsForPapers.Find(id);
            if (callForPapers == null)
            {
                return HttpNotFound();
            }
            return View(callForPapers);
        }

        // POST: CallForPapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Acronym,Name,StartDate,DeadlineAbstract,DeadlineProposal,Topic_Id1,Topic_Name")] CallForPapers callForPapers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callForPapers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(callForPapers);
        }

        // GET: CallForPapers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallForPapers callForPapers = db.CallsForPapers.Find(id);
            if (callForPapers == null)
            {
                return HttpNotFound();
            }
            return View(callForPapers);
        }

        // POST: CallForPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CallForPapers callForPapers = db.CallsForPapers.Find(id);
            db.CallsForPapers.Remove(callForPapers);
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
