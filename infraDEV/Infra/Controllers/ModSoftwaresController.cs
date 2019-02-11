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
    public class ModSoftwaresController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

       
        public ActionResult Index()
        {
            var modSoftwares = db.ModSoftwares.Include(m => m.Fabricante);
            return View(modSoftwares.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModSoftware modSoftware = db.ModSoftwares.Find(id);
            if (modSoftware == null)
            {
                return HttpNotFound();
            }
            return View(modSoftware);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModSoftwareID,Modelo,FabricanteID")] ModSoftware modSoftware)
        {
            if (ModelState.IsValid)
            {
                db.ModSoftwares.Add(modSoftware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modSoftware.FabricanteID);
            return View(modSoftware);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModSoftware modSoftware = db.ModSoftwares.Find(id);
            if (modSoftware == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modSoftware.FabricanteID);
            return View(modSoftware);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModSoftwareID,Modelo,FabricanteID")] ModSoftware modSoftware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modSoftware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modSoftware.FabricanteID);
            return View(modSoftware);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModSoftware modSoftware = db.ModSoftwares.Find(id);
            if (modSoftware == null)
            {
                return HttpNotFound();
            }
            return View(modSoftware);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModSoftware modSoftware = db.ModSoftwares.Find(id);
            db.ModSoftwares.Remove(modSoftware);
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
