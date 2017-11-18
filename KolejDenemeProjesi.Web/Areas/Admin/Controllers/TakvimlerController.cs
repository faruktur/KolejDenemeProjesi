using KolejDenemeProjesi.BusinessLayer.Managers;
using KolejDenemeProjesi.Entities;
using KolejDenemeProjesi.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class TakvimlerController : Controller
    {
        private TakvimlerManager TakvimlerManager = new TakvimlerManager();
        private DonemManager DonemManager = new DonemManager();
        private OgrenimTipManager OgrenimTipManager = new OgrenimTipManager();

        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                return View(new DonemTakvimi() { Donem = new Donemler()});
            }
            var model = TakvimlerManager.ListQueryable().Include(c => c.GunBilgileri).Include(c => c.Donem).Where(c => c.Donem.Id == id.Value).ToList();
            return View(model);
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(),"Id","OgrenimTip");
            return View(new DonemTakvimi() { Donem=new Donemler(){Id=id}});
        }
        public ActionResult Edit(int? id)
        {

            if(id==null)
            {
                return null;
            }
            var model = TakvimlerManager.Find(c => c.Id == id);
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return PartialView("_Edit", model);
        }
        

        // POST: Admin/Takvimler/Create
        [HttpPost]
        public ActionResult Create(DonemTakvimi model)
        {
            //JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();
            if(ModelState.IsValid)
            {
                DonemTakvimi dbdata = new DonemTakvimi()
                {
                    Aciklama=model.Aciklama,
                    BaslangicTarihi=model.BaslangicTarihi,
                    BitisTarihi=model.BitisTarihi,
                    İlkDersTarihi=model.İlkDersTarihi,
                    SonDersTarihi=model.SonDersTarihi,
                    MezuniyetTarihi=model.MezuniyetTarihi,
                    EgitimGunSayisi=model.EgitimGunSayisi,
                    Donem=DonemManager.Find(c=>c.Id==model.Donem.Id),
                    GunlukSure=model.GunlukSure,
                    OgrenimTip=OgrenimTipManager.Find(c=>c.Id==model.OgrenimTip.Id)
                };
                if(TakvimlerManager.Insert(dbdata)>0)
                {
                    return RedirectToAction("Index",new { id=dbdata.Donem.Id});
                }
            }
            else
            {
                ErrorViewModel errorviewmodel = new ViewModels.ErrorViewModel() { Header="İşlem tamamlanamadı."};
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        errorviewmodel.Items.Add( new Entities.Messages.ErrorMessageObj { Message= error.ErrorMessage,Code=Entities.Messages.ErrorMessages.ModelStateErrors});
                    }
                }
                
            }
            return null;
        }
        
       

        // POST: Admin/Takvimler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Message Methods
        [HttpPost]
        public ActionResult Ok(OkViewModel model)
        {
            return PartialView("_Ok", model);
        }
        [HttpPost]
        public ActionResult Error(ErrorViewModel model)
        {
            return PartialView("_Error", model);
        }
        [HttpPost]
        public ActionResult Warning(WarningViewModel model)
        {
            return PartialView("_Warning", model);
        }
        [HttpPost]
        public ActionResult Info(InfoViewModel model)
        {
            return PartialView("_Info", model);
        }
    }
}
