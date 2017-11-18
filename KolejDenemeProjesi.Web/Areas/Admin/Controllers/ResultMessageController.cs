using KolejDenemeProjesi.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class ResultMessageController : Controller
    {

        //Message Methods
        public PartialViewResult Ok(OkViewModel model)
        {
            return PartialView("_Ok", model);
        }

        public PartialViewResult Error(ErrorViewModel model)
        {
            return PartialView("_Error", model);
        }

        public PartialViewResult Warning(WarningViewModel model)
        {
            return PartialView("_Warning", model);
        }

        public PartialViewResult Info(InfoViewModel model)
        {
            return PartialView("_Info", model);
        }
    }
}