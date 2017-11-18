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
    public class SinifSeviyeleriController : Controller
    {
        private SinifSeviyeleriManager SinifSeviyeleriManager = new SinifSeviyeleriManager();
        private OgrenimTipManager OgrenimTipManager = new OgrenimTipManager();
        // GET: Admin/SinifSeviyeleri
        public ActionResult Index()
        {
            return View(SinifSeviyeleriManager.ListQueryable().Include(c=>c.OgrenimTip).ToList());
        }

        // GET: Admin/SinifSeviyeleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinifSeviyeleri sinifSeviyeleri = SinifSeviyeleriManager.Find(c=>c.Id==id);
            if (sinifSeviyeleri == null)
            {
                return HttpNotFound();
            }
            return View(sinifSeviyeleri);
        }

        // GET: Admin/SinifSeviyeleri/Create
        public ActionResult Create()
        {

            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(),"Id","OgrenimTip");

            return View();
        }

        // POST: Admin/SinifSeviyeleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SinifSeviyeleri sinifSeviyeleri,int OgrenimTipId)
        {
            if (ModelState.IsValid)
            {
                SinifSeviyeleri data = new SinifSeviyeleri() {
                    Seviye = sinifSeviyeleri.Seviye,
                    OgrenimTip = OgrenimTipManager.Find(c => c.Id == OgrenimTipId)
                };
                if (SinifSeviyeleriManager.Insert(data) > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin.");
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return View(sinifSeviyeleri);
        }

        // GET: Admin/SinifSeviyeleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinifSeviyeleri sinifSeviyeleri = SinifSeviyeleriManager.Find(c => c.Id == id);
            if (sinifSeviyeleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return View(sinifSeviyeleri);
        }

        // POST: Admin/SinifSeviyeleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SinifSeviyeleri sinifSeviyeleri,int OgrenimTipId)
        {
            if (ModelState.IsValid)
            {
                SinifSeviyeleri data = SinifSeviyeleriManager.Find(c => c.Id == sinifSeviyeleri.Id);
                data.OgrenimTip = OgrenimTipManager.Find(c => c.Id == OgrenimTipId);
                data.Seviye = sinifSeviyeleri.Seviye;
                if(SinifSeviyeleriManager.Update(data)>0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt edilirken bir hata oluştu.Tekrar deneyin."); 
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            return View(sinifSeviyeleri);
        }

        // GET: Admin/SinifSeviyeleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinifSeviyeleri sinifSeviyeleri = SinifSeviyeleriManager.Find(c => c.Id == id);
            if (sinifSeviyeleri == null)
            {
                return HttpNotFound();
            }
            return View(sinifSeviyeleri);
        }

        // POST: Admin/SinifSeviyeleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SinifSeviyeleri sinifSeviyeleri = SinifSeviyeleriManager.Find(c => c.Id == id);
            SinifSeviyeleriManager.Delete(sinifSeviyeleri);
            return RedirectToAction("Index");
        }

       
    }
}
