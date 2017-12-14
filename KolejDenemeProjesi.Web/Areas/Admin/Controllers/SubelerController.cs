using KolejDenemeProjesi.BusinessLayer.Managers;
using KolejDenemeProjesi.Entities;
using KolejDenemeProjesi.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class SubelerController : Controller
    {
        private SubelerManager SubelerManager = new SubelerManager();
        private OgrenimTipManager OgrenimTipManager = new OgrenimTipManager();
        private SinifSeviyeleriManager SinifSeviyeleriManager = new SinifSeviyeleriManager(); 
        public ActionResult Index()
        {
            return View(SubelerManager.ListQueryable().Include(c=>c.Seviye).Include(c=>c.Ogrenciler).Include(c=>c.OgrenimTip).ToList());
        }

        // GET: Admin/Subeler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return View();
        }
     
        public ActionResult GetSeviyeList(int id)
        {
            return PartialView("_SinifSeviyeleri",SinifSeviyeleriManager.ListQueryable().Where(c=>c.OgrenimTip.Id==id).ToList());
        }

        // POST: Admin/Subeler/Create
        [HttpPost]
        public ActionResult Create(Subeler model)
        {
            if(ModelState.IsValid)
            {
                Subeler db_data = new Subeler() {
                    OgrenimTip =OgrenimTipManager.Find(c=>c.Id==model.OgrenimTip.Id),
                    Seviye=SinifSeviyeleriManager.Find(c=>c.Id==model.Seviye.Id),
                    SubeAdi=model.SubeAdi
                };
                if(SubelerManager.Insert(db_data)>0)
                {
                    TempData["okviewmodel"] = new OkViewModel() { Items = { "Şube oluştuldu." }  };
                    return RedirectToAction("Index");
                }
                TempData["errorviewmodel"] = new ErrorViewModel() { Items = { new Entities.Messages.ErrorMessageObj() { Code = Entities.Messages.ErrorMessages.ModelStateErrors, Message = "Beklenmedik bir hata oluştu." } } };
            }else
            {
                ErrorViewModel errorviewmodel = new ViewModels.ErrorViewModel();
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        errorviewmodel.Items.Add(new Entities.Messages.ErrorMessageObj() { Code = Entities.Messages.ErrorMessages.ModelStateErrors, Message = error.ErrorMessage });
                    }
                }
                TempData["errorviewmodel"] = errorviewmodel;
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return View(model);
        }

     
    }
}
