using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class MultipleSelectionController : Controller
    {
        private DatabaseContextEntities1 TestModel = new DatabaseContextEntities1();
      
        public ActionResult Create1()
        {
            MultipleSelectionViewModel mviewModel = new MultipleSelectionViewModel();
            mviewModel.Topic1 = TestModel.Topic.Where(topic => topic.Id == topic.Id).ToList().
                Select(topic => new SelectListItem
                {
                    Value = topic.Id.ToString(),
                    Text = topic.Name
                }).ToList();
            mviewModel.Topic1.Insert(0, new SelectListItem
            {
                Value = "-1",
                Text = "Please select a Topic"
            });
            mviewModel.Topic2 = TestModel.Topic.Where(topic => topic.Id == topic.Id).ToList().
                Select(topic => new SelectListItem
                {
                    Value = topic.Id.ToString(),
                    Text = topic.Description
                }).ToList();
            mviewModel.Topic2.Insert(0, new SelectListItem
            {
                Value = "-1",
                Text = "Please select a Topic"
            });
            return View("Create1",mviewModel);
        }
        [HttpGet]
        public ActionResult filterCatlevel2(int id)
        {
            return Json(this.TestModel.Topic.Where(c => c.Id == id).ToList()
                .Select(topic => new SelectListItem
                {
                    Value = topic.Id.ToString(),
                    Text = topic.Description
                }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}