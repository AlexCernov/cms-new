using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using System.Web.Mvc;

namespace CMS.ViewModels
{
    public class MultipleSelectionViewModel
    {
        public List<SelectListItem> Topic1
        {
            get;
            set;
        }

        public List<SelectListItem> Topic2
        {
            get;
            set;
        }

        public int CategoryIdLevel1
        {
            get;
            set;
        }

        public int CategoryIdLevel2
        {
            get;
            set;
        }

    }
}