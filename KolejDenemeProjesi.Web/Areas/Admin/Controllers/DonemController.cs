using KolejDenemeProjesi.BusinessLayer.Managers;
using KolejDenemeProjesi.Entities;
using KolejDenemeProjesi.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class DonemController : Controller
    {
        private DonemManager DonemManager = new DonemManager();
        public ActionResult Index()
        {
            var model = DonemManager.ListQueryable().Include(c => c.KayitliOgrenciler).Include(c => c.Takvimler).ToList();

            return View(model);
        }

        

        
        public ActionResult Create()
        {
            
            return View();
        }
     
        [HttpPost]
        public ActionResult Create(Donemler model)
        {
            if(ModelState.IsValid)
            {
                Donemler dbdata = new Donemler() {  
                    Aciklama=model.Aciklama,
                    DonemKodu=model.DonemKodu,
                    BaslangicTarihi=DateTime.Now,
                    BitisTarihi=DateTime.Now,
                };
                if(DonemManager.Insert(dbdata) >0)
                {
                    OkViewModel okviewmodel = new ViewModels.OkViewModel() { Title="İşlem  Tamamlandı.",Header="Başarılı!",IsRedirecting=false};
                    okviewmodel.Items.Add("Dönem Oluşturuldu.");
                    TempData["okviewmodel"] = okviewmodel;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            ErrorViewModel errorviewmodel = new ErrorViewModel() { Title="İşlem Tamamlanamadı!",IsRedirecting=false,Header="Hata." };
            foreach (var item in ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errorviewmodel.Items.Add(new Entities.Messages.ErrorMessageObj { Message=error.ErrorMessage,Code=Entities.Messages.ErrorMessages.ModelStateErrors });
                }
            }
            TempData["errorviewmodel"] = errorviewmodel;
            return View(model);
        }

       
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header="Parametre bozuk!",Items = {"Yapılan işlemi kontrol edip tekrar deneyiniz."} };
                return RedirectToAction("Index");
            }
            var model = DonemManager.Find(c => c.Id == id.Value);
            if(model==null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header = "Uyarı!",Title="Aranılan bilgiye ulaşılamadı.", Items = { "Yapılan işlemi kontrol edip tekrar deneyiniz." } };
                return RedirectToAction("Index");
            }
            return View(model);
        }

      
        [HttpPost]
        public ActionResult Edit(Donemler model)
        {
            if (ModelState.IsValid)
            {
                Donemler dbdata = DonemManager.Find(c => c.Id == model.Id);
                dbdata.Aciklama = model.Aciklama;
                dbdata.DonemKodu = model.DonemKodu;
                dbdata.BaslangicTarihi = model.BaslangicTarihi;
                dbdata.BitisTarihi = model.BitisTarihi;
                if (DonemManager.Update(dbdata) > 0)
                {
                    OkViewModel okviewmodel = new ViewModels.OkViewModel() { Title = "İşlem  Tamamlandı.", Header = "Başarılı!", IsRedirecting = false };
                    okviewmodel.Items.Add("Dönem Bilgisi Güncellendi.");
                    TempData["okviewmodel"] = okviewmodel;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            ErrorViewModel errorviewmodel = new ErrorViewModel() { Title = "İşlem Tamamlanamadı!", IsRedirecting = false, Header = "Hata." };
            foreach (var item in ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errorviewmodel.Items.Add(new Entities.Messages.ErrorMessageObj { Message = error.ErrorMessage, Code = Entities.Messages.ErrorMessages.ModelStateErrors });
                }
            }
            TempData["errorviewmodel"] = errorviewmodel;
            return View(model);
        }

        public ActionResult Details(int? id)
        {
          
            if(id==null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header = "Parametre bozuk!", Items = { "Yapılan işlemi kontrol edip tekrar deneyiniz." } };
                return RedirectToAction("Index");
            }
            var model = DonemManager.ListQueryable().Include(c => c.KayitliOgrenciler).Include(c => c.Takvimler).FirstOrDefault(c=>c.Id==id.Value);
            if (model == null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header = "Uyarı!", Title = "Aranılan bilgiye ulaşılamadı.", Items = { "Yapılan işlemi kontrol edip tekrar deneyiniz." } };
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header = "Parametre bozuk!", Items = { "Yapılan işlemi kontrol edip tekrar deneyiniz." } };
                return RedirectToAction("Index");
            }
            var model = DonemManager.ListQueryable().Include(c => c.KayitliOgrenciler).Include(c => c.Takvimler).FirstOrDefault(c => c.Id == id.Value);
            if (model == null)
            {
                TempData["warningviewmodel"] = new WarningViewModel() { Header = "Uyarı!", Title = "Aranılan bilgiye ulaşılamadı.", Items = { "Yapılan işlemi kontrol edip tekrar deneyiniz." } };
                return RedirectToAction("Index");
            }
            TempData["warningviewmodel"] = new WarningViewModel() { Header = "Silmek istediğinize emin misiniz?", Title = "Silmek istediğinize emin misiniz?", Items = { "Ekrandaki dönem ve görüntülenen bilgiler silinecek,onaylıyor musunuz?" } };
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete()
        {
            TempData["okviewmodel"] = new OkViewModel() { };
            return RedirectToAction("Index");
        }

        //Message Methods
        public PartialViewResult Ok(List<string> id)
        {
            return PartialView("_Ok", new OkViewModel() { Items=id});
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
