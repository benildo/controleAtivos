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
    public class ModImpressorasController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modImpressoras = db.ModImpressoras.Include(m => m.Fabricante1).Include(m => m.Fornecedor1);
            return View(modImpressoras.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModImpressora modImpressora = db.ModImpressoras.Find(id);
            if (modImpressora == null)
            {
                return HttpNotFound();
            }
            return View(modImpressora);
        }

        
        public ActionResult Create()
        {
            ViewBag.Fabricante = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.Fornecedor = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModImpressoraID,Modelo,Fabricante,Fornecedor")] ModImpressora modImpressora)
        {
            if (ModelState.IsValid)
            {
                db.ModImpressoras.Add(modImpressora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fabricante = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modImpressora.Fabricante);
            ViewBag.Fornecedor = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modImpressora.Fornecedor);
            return View(modImpressora);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModImpressora modImpressora = db.ModImpressoras.Find(id);
            if (modImpressora == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fabricante = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modImpressora.Fabricante);
            ViewBag.Fornecedor = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modImpressora.Fornecedor);
            return View(modImpressora);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModImpressoraID,Modelo,Fabricante,Fornecedor")] ModImpressora modImpressora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modImpressora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fabricante = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modImpressora.Fabricante);
            ViewBag.Fornecedor = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modImpressora.Fornecedor);
            return View(modImpressora);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModImpressora modImpressora = db.ModImpressoras.Find(id);
            if (modImpressora == null)
            {
                return HttpNotFound();
            }
            return View(modImpressora);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModImpressora modImpressora = db.ModImpressoras.Find(id);
            db.ModImpressoras.Remove(modImpressora);
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
