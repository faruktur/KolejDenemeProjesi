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
    public class GunTipleriController : Controller
    {
        private GunTipleriManager GunTipleriManager = new GunTipleriManager();

        // GET: Admin/GunTipleri
        public ActionResult Index()
        {
            return View(GunTipleriManager.ListQueryable().Include(c=>c.GunBilgileri).ToList());
        }

        // GET: Admin/GunTipleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GunTipleri gunTipleri = GunTipleriManager.Find(c=>c.Id==id);
            if (gunTipleri == null)
            {
                return HttpNotFound();
            }
            return View(gunTipleri);
        }

        // GET: Admin/GunTipleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GunTipleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GunTipleri gunTipleri)
        {
            if (ModelState.IsValid)
            {
                GunTipleri data = new GunTipleri() {GunTipAdi=gunTipleri.GunTipAdi };
                if(GunTipleriManager.Insert(data)>0)
                { 
                return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }

            return View(gunTipleri);
        }

        // GET: Admin/GunTipleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GunTipleri gunTipleri = GunTipleriManager.Find(c => c.Id == id);
            if (gunTipleri == null)
            {
                return HttpNotFound();
            }
            return View(gunTipleri);
        }

        // POST: Admin/GunTipleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OlusturulmaTarihi,DegistirilmeTarihi")] GunTipleri gunTipleri)
        {
            if (ModelState.IsValid)
            {
                GunTipleri data = GunTipleriManager.Find(c => c.Id == gunTipleri.Id);
                data.GunTipAdi = gunTipleri.GunTipAdi;
                if(GunTipleriManager.Update(data)>0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            return View(gunTipleri);
        }

        // GET: Admin/GunTipleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GunTipleri gunTipleri = GunTipleriManager.Find(c => c.Id == id);
            if (gunTipleri == null)
            {
                return HttpNotFound();
            }
            return View(gunTipleri);
        }

        // POST: Admin/GunTipleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GunTipleri gunTipleri = GunTipleriManager.Find(c => c.Id == id);
            GunTipleriManager.Delete(gunTipleri);

            return RedirectToAction("Index");
        }

     
    }
}
