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
    public class PCMemberController : Controller
    {
        IPCMemberService PCMemberService;

        public PCMemberController(IPCMemberService repo)
        {
            PCMemberService = repo;
        }

        public PCMemberController()
        {
            PCMemberService = new PCMemberService(new PCMemberRepository());
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
        public ActionResult Registration(PCMember pcmember)
        {
            try
            {
                var model = new RegistrationViewModel(ModelState.IsValid, pcmember, PCMemberService);
                return View(model);
            }
            catch (System.Exception e)
            {
                throw new InternetException("Cannot request the correspondind viewmodel!\n");
            }
        }
    }
}