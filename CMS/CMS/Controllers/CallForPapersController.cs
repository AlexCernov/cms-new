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

namespace CMS.Controllers
{
	public class CallForPapersController : Controller
	{

		// THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
		// how things work there

		// There might not be a use for all the views/methods that were automatically generated

		private readonly CallForPaperService CallForPaperService;

		public CallForPapersController()
		{
			CallForPaperService = new CallForPaperService(new CallForPapersRepository());
		}

		// GET: CallForPapers
		public ActionResult Index()
		{
			return View(CallForPaperService.FindAll());
		}

		// GET: CallForPapers/Create
		public ActionResult Create()
		{
			if (Request.IsAuthenticated)
			{
				return RedirectToAction("PermissionDenied");
			}
			CreateCallForPapersViewModel model = new CreateCallForPapersViewModel();
			return View(model);
		}
        //GET: CallForPapers/Delete
        public ActionResult Delete()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            DeleteCallForPapersViewModel model = new DeleteCallForPapersViewModel();
            return View(model);
        }
        //GET: CallForPapers/Details
        public ActionResult Details()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            DetailsCallForPapersViewModel model = new DetailsCallForPapersViewModel();
            return View(model);
        }

        
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CallForPapers callForPapers)
		{
			try
			{
                CreateCallForPapersViewModel model = new CreateCallForPapersViewModel(ModelState.IsValid, callForPapers, CallForPaperService);
				return View(model);
			}
			catch (System.Exception)
			{
				return RedirectToRoute("~/Shared/Error");
			}
		}
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CallForPapers callforpaper)
        {
            try
            {
                DeleteCallForPapersViewModel model = new DeleteCallForPapersViewModel(ModelState.IsValid, callforpaper, CallForPaperService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(CallForPapers callforpaper)
        {
            try
            {
                DetailsCallForPapersViewModel model = new DetailsCallForPapersViewModel(ModelState.IsValid, callforpaper, CallForPaperService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        //     // GET: CallForPapers/Edit/5
        //     public ActionResult Edit(int? id)
        //     {
        //         if (id == null)
        //         {
        //             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //         }
        //CallForPapers callForPapers = CallForPaperService.FindAll().ElementAt((int)id);
        //         if (callForPapers == null)
        //         {
        //             return HttpNotFound();
        //         }
        //         return View(callForPapers);
        //     }

        // POST: CallForPapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //     [HttpPost]
        //     [ValidateAntiForgeryToken]
        //     public ActionResult Edit([Bind(Include = "Id,Acronym,Name,StartDate,DeadlineAbstract,DeadlineProposal")] CallForPapers callForPapers)
        //     {
        //         if (ModelState.IsValid)
        //         {
        //             CallForPaperService.Update(callForPapers);
        //             return RedirectToAction("Index");
        //         }
        //         return View(callForPapers);
        //     }
    }
}
