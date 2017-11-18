using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class OgrenciController : Controller
    {
        
        public ActionResult Index()
        {
            //TODO: Ogrenci ile ilgili işlemleri listele
            return View();
        }
        public ActionResult Liste()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();
        }
    }
}