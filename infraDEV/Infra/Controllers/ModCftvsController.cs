using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infra.Models;

namespace Infra.Controllers
{
    public class ModCftvsController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modCftvs = db.ModCftvs.Include(m => m.Fabricante);
            return View(modCftvs.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModCftv modCftv = db.ModCftvs.Find(id);
            if (modCftv == null)
            {
                return HttpNotFound();
            }
            return View(modCftv);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModCftvID,Nome,FabricanteID,Modelo")] ModCftv modCftv)
        {
            if (ModelState.IsValid)
            {
                db.ModCftvs.Add(modCftv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modCftv.FabricanteID);
            return View(modCftv);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModCftv modCftv = db.ModCftvs.Find(id);
            if (modCftv == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modCftv.FabricanteID);
            return View(modCftv);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModCftvID,Nome,FabricanteID,Modelo")] ModCftv modCftv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modCftv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modCftv.FabricanteID);
            return View(modCftv);
        }

        // GET: ModCftvs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModCftv modCftv = db.ModCftvs.Find(id);
            if (modCftv == null)
            {
                return HttpNotFound();
            }
            return View(modCftv);
        }

        // POST: ModCftvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModCftv modCftv = db.ModCftvs.Find(id);
            db.ModCftvs.Remove(modCftv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
