using KolejDenemeProjesi.BusinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class OgrenciController : Controller
    {

        OgrenciManager OgrenciManager = new OgrenciManager();


        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create()
        {
            return View();

        }
       
    }
}