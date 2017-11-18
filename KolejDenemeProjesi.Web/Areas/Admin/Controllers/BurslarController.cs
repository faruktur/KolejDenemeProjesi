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
    public class BurslarController : Controller
    {
        private BursManager BurslarManager = new BursManager();
        private BursTipleriManager BursTipleriManager = new BursTipleriManager();
        private DonemManager DonemManager = new DonemManager();
        private OgrenciManager OgrenciManager = new OgrenciManager();
        // GET: Admin/Burslar
        public ActionResult Index()
        {
            return View(BurslarManager.ListQueryable().Include(c => c.BursTipi).Include(c => c.Ogrenci).ToList());
        }
        // GET: Admin/Burslar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = BurslarManager.Find(c=>c.Id==id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            return View(burslar);
        }

        // GET: Admin/Burslar/Create
        public ActionResult Create()
        {
            ViewBag.Ogrenciler = OgrenciManager.List();
            ViewBag.BursTipleri = new SelectList(BursTipleriManager.List(), "Id", "BursTipi");
            ViewBag.Donemler = new SelectList(DonemManager.List(), "Id", "Aciklama");
            return View();
        }

        // POST: Admin/Burslar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Burslar burslar)
        {
            if (ModelState.IsValid)
            {
                Burslar data = new Burslar() {
                    Aciklama = burslar.Aciklama,
                    Miktar = burslar.Miktar,
                    Ogrenci = OgrenciManager.Find(c => c.Id == burslar.Ogrenci.Id),
                    BursTipi = BursTipleriManager.Find(c => c.Id == burslar.BursTipi.Id),
                    Donem=DonemManager.Find(c=>c.Id==burslar.Donem.Id),
    
                };
                if(BurslarManager.Insert(data)>0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            ViewBag.Ogrenciler = OgrenciManager.List();
            ViewBag.BursTipleri = new SelectList(BursTipleriManager.List(), "Id", "BursTipi");
            ViewBag.Donemler = new SelectList(DonemManager.List(), "Id", "Aciklama");
            return View(burslar);
        }

        // GET: Admin/Burslar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = BurslarManager.Find(c=>c.Id==id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ogrenciler = OgrenciManager.List();
            ViewBag.BursTipleri = new SelectList(BursTipleriManager.List(), "Id", "BursTipi");
            ViewBag.Donemler = new SelectList(DonemManager.List(), "Id", "Aciklama");
            return View(burslar);
        }

        // POST: Admin/Burslar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Burslar burslar)
        {
            if (ModelState.IsValid)
            {
                Burslar data = BurslarManager.Find(c => c.Id == burslar.Id);
                data.Miktar = burslar.Miktar;
                data.Aciklama = burslar.Aciklama;
                data.Donem = DonemManager.Find(c => c.Id == burslar.Donem.Id);
                data.Ogrenci = OgrenciManager.Find(c => c.Id == burslar.Ogrenci.Id);
                data.BursTipi = BursTipleriManager.Find(c => c.Id == burslar.BursTipi.Id);
                if(BurslarManager.Update(data)>0)
                { 
                return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyiniz.");
            }
            ViewBag.Ogrenciler = OgrenciManager.List();
            ViewBag.BursTipleri = new SelectList(BursTipleriManager.List(), "Id", "BursTipi");
            ViewBag.Donemler = new SelectList(DonemManager.List(), "Id", "Aciklama");
            return View(burslar);
        }

        // GET: Admin/Burslar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Burslar burslar = BurslarManager.Find(c => c.Id == id);
            if (burslar == null)
            {
                return HttpNotFound();
            }
            return View(burslar);
        }

        // POST: Admin/Burslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Burslar burslar = BurslarManager.Find(c => c.Id == id);
            BurslarManager.Delete(burslar);
            return RedirectToAction("Index");
        }

        
    }
}
