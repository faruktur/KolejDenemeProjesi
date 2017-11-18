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
    public class BursTipleriController : Controller
    {
        private BursTipleriManager BursTipleriManager = new BursTipleriManager();

        
        public ActionResult Index()
        {
            return View(BursTipleriManager.ListQueryable().Include(c=>c.Burslar).ToList());
        }

        // GET: Admin/BursTipleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BursTipleri bursTipleri = BursTipleriManager.Find(c=>c.Id==id);
            if (bursTipleri == null)
            {
                return HttpNotFound();
            }
            return View(bursTipleri);
        }

        // GET: Admin/BursTipleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BursTipleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BursTipleri bursTipleri)
        {
            if (ModelState.IsValid)
            {
                BursTipleri data = new BursTipleri()
                {
                    BursTipi = bursTipleri.BursTipi
                };
                if(BursTipleriManager.Insert(data)>0)
                { 
                   return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin");
            }

            return View(bursTipleri);
        }

        // GET: Admin/BursTipleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BursTipleri bursTipleri = BursTipleriManager.Find(c => c.Id == id);
            if (bursTipleri == null)
            {
                return HttpNotFound();
            }
            return View(bursTipleri);
        }

        // POST: Admin/BursTipleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BursTipleri bursTipleri)
        {
            if (ModelState.IsValid)
            {
                BursTipleri data = BursTipleriManager.Find(c => c.Id == bursTipleri.Id);
                data.BursTipi = bursTipleri.BursTipi;
                if(BursTipleriManager.Update(data)>0)
                { 
                return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            return View(bursTipleri);
        }

        // GET: Admin/BursTipleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BursTipleri bursTipleri = BursTipleriManager.Find(c => c.Id == id);
            if (bursTipleri == null)
            {
                return HttpNotFound();
            }
            return View(bursTipleri);
        }

        // POST: Admin/BursTipleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BursTipleri bursTipleri = BursTipleriManager.Find(c => c.Id == id);
            BursTipleriManager.Delete(bursTipleri);
            return RedirectToAction("Index");
        }

       
    }
}
