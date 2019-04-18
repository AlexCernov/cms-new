using CMS.Exception;
using CMS.Models;
using CMS.Repository;
using CMS.Service;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
	public class AuthorController : Controller
	{
		IAuthorService AuthorService;

		public AuthorController(IAuthorService repo)
		{
			AuthorService = repo;
		}

		public AuthorController()
		{
			AuthorService = new AuthorService(new AuthorRepository());
		}

		// GET:PCMember
		[HttpGet]
		public ActionResult Registration()
		{
			if (Request.IsAuthenticated)
			{
				return RedirectToAction("PermissionDenied");
			}
			RegistrationViewModel model = new RegistrationViewModel();
			return View(model);
		}


		[HttpPost]
		public ActionResult Registration(Author author)
		{
			try
			{
				var model = new RegistrationAuthorViewModel(ModelState.IsValid, author, AuthorService);
				return View(model);
			}
			catch (System.Exception e)
			{
				throw new InternetException("Cannot request the correspondind viewmodel!\n");
			}
		}
	}
}