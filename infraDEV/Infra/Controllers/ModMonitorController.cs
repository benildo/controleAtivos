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
    public class ModMonitorController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modMonitors = db.ModMonitors.Include(m => m.Fabricante).Include(m => m.Fornecedor);
            return View(modMonitors.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMonitor modMonitor = db.ModMonitors.Find(id);
            if (modMonitor == null)
            {
                return HttpNotFound();
            }
            return View(modMonitor);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModMonitorID,FabricanteID,FornecedorID,Modelo")] ModMonitor modMonitor)
        {
            if (ModelState.IsValid)
            {
                db.ModMonitors.Add(modMonitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMonitor.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMonitor.FornecedorID);
            return View(modMonitor);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMonitor modMonitor = db.ModMonitors.Find(id);
            if (modMonitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMonitor.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMonitor.FornecedorID);
            return View(modMonitor);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModMonitorID,FabricanteID,FornecedorID,Modelo")] ModMonitor modMonitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modMonitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMonitor.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMonitor.FornecedorID);
            return View(modMonitor);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMonitor modMonitor = db.ModMonitors.Find(id);
            if (modMonitor == null)
            {
                return HttpNotFound();
            }
            return View(modMonitor);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModMonitor modMonitor = db.ModMonitors.Find(id);
            db.ModMonitors.Remove(modMonitor);
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
