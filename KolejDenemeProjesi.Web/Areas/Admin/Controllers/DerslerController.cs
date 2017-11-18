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
    public class DerslerController : Controller
    {
        private DerslerManager DerslerManager = new DerslerManager();
        private OgrenimTipManager OgrenimTipManager = new OgrenimTipManager();
        private SinifSeviyeleriManager SinifSeviyeleriManager = new SinifSeviyeleriManager();
        // GET: Admin/Dersler
        public ActionResult Index()
        {
            return View(DerslerManager.ListQueryable().Include(c=>c.OgrenimTip).Include(c=>c.SinifSeviye).ToList());
        }

        // GET: Admin/Dersler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dersler dersler = DerslerManager.Find(c=>c.Id==id);
            if (dersler == null)
            {
                return HttpNotFound();
            }
            return View(dersler);
        }

        // GET: Admin/Dersler/Create
        public ActionResult Create()
        {
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(),"Id","OgrenimTip");
            ViewBag.SinifSeviyeleri = new SelectList(SinifSeviyeleriManager.List(), "Id", "Seviye");

            return View();
        }

        // POST: Admin/Dersler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dersler dersler)
        {
            if (ModelState.IsValid)
            {
                Dersler data = new Dersler()
                {
                    DersAdi = dersler.DersAdi,
                    OgrenimTip = OgrenimTipManager.Find(c => c.Id == dersler.OgrenimTip.Id),
                    SinifSeviye=SinifSeviyeleriManager.Find(c=>c.Id==dersler.SinifSeviye.Id)
                };
                if(DerslerManager.Insert(data)>0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Veritabanına kayıt yapılırken bir hata oluştu.Tekrar deneyin.");
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            ViewBag.SinifSeviyeleri = new SelectList(SinifSeviyeleriManager.List(), "Id", "Seviye");

            return View(dersler);
        }

        // GET: Admin/Dersler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dersler dersler = DerslerManager.Find(c => c.Id == id);


            if (dersler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            ViewBag.SinifSeviyeleri = new SelectList(SinifSeviyeleriManager.List(), "Id", "Seviye");

            return View(dersler);
        }

        // POST: Admin/Dersler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dersler dersler)
        {
            if (ModelState.IsValid)
            {
                Dersler data = DerslerManager.Find(c => c.Id == dersler.Id);
                data.DersAdi = dersler.DersAdi;
                data.OgrenimTip = OgrenimTipManager.Find(c => c.Id == dersler.OgrenimTip.Id);
                data.SinifSeviye = SinifSeviyeleriManager.Find(c => c.Id == dersler.SinifSeviye.Id);

                return RedirectToAction("Index");
            }
            ViewBag.OgrenimTipleri = new SelectList(OgrenimTipManager.List(), "Id", "OgrenimTip");
            ViewBag.SinifSeviyeleri = new SelectList(SinifSeviyeleriManager.List(), "Id", "Seviye");
            return View(dersler);
        }

        // GET: Admin/Dersler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dersler dersler = DerslerManager.Find(c => c.Id == id);
            if (dersler == null)
            {
                return HttpNotFound();
            }
            return View(dersler);
        }

        // POST: Admin/Dersler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dersler dersler = DerslerManager.Find(c => c.Id == id);
            DerslerManager.Delete(dersler);
            return RedirectToAction("Index");
        }
    }
}
