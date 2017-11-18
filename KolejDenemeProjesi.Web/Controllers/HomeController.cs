using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Controllers
{
    public class HomeController : Controller
    {      
        public ActionResult Index()
        {
            //TODO : Login işlemi ve yönlendirme
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            return View();
        }
    }
}