using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KolejDenemeProjesi.Entities;
using KolejDenemeProjesi.BusinessLayer.Managers;

namespace KolejDenemeProjesi.Web.Areas.Admin.Controllers
{
    public class OgrenimTipleriController : Controller
    {
        private OgrenimTipManager OgrenimTipManager = new OgrenimTipManager();

        // GET: Admin/OgrenimTipleri
        public ActionResult Index()
        {
            OgrenimTipManager.List();
            return View(OgrenimTipManager.ListQueryable().Include(c=>c.SinifSeviyeleri).ToList());
        }

        // GET: Admin/OgrenimTipleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimTipleri ogrenimTipleri = OgrenimTipManager.ListQueryable().Include(c=>c.SinifSeviyeleri).FirstOrDefault(c=>c.Id==id);
            if (ogrenimTipleri == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimTipleri);
        }

        // GET: Admin/OgrenimTipleri/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OgrenimTipleri ogrenimTipleri)
        {
            if (ModelState.IsValid)
            {
                OgrenimTipleri data = new OgrenimTipleri() {
                    OgrenimTip=ogrenimTipleri.OgrenimTip
                };
                if(OgrenimTipManager.Insert(data)>0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Lütfen sayfayı yenileyin.");
            }
            return View(ogrenimTipleri);
        }

        // GET: Admin/OgrenimTipleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimTipleri ogrenimTipleri = OgrenimTipManager.Find(c => c.Id == id);
            if (ogrenimTipleri == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimTipleri);
        }

        // POST: Admin/OgrenimTipleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OgrenimTipleri ogrenimTipleri)
        {
            if (ModelState.IsValid)
            {
                OgrenimTipleri data = OgrenimTipManager.Find(c => c.Id == ogrenimTipleri.Id);
                data.OgrenimTip = ogrenimTipleri.OgrenimTip;
                int db_result = OgrenimTipManager.Update(data);
                if(!(db_result>0))
                {
                    ModelState.AddModelError("", "Veri tabanına kayıt edilirken bir hata oluştu.Tekrar deneyin...");
                    return View(ogrenimTipleri);
                }
                return RedirectToAction("Index");
            }
            return View(ogrenimTipleri);
        }

        // GET: Admin/OgrenimTipleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimTipleri ogrenimTipleri = OgrenimTipManager.Find(c => c.Id == id.Value);
            if (ogrenimTipleri == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimTipleri);
        }

        // POST: Admin/OgrenimTipleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            OgrenimTipleri ogrenimTipleri = OgrenimTipManager.Find(c => c.Id == id.Value);
            OgrenimTipManager.Delete(ogrenimTipleri);
            return RedirectToAction("Index");
        }

        
    }
}
