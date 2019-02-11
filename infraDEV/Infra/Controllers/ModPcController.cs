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
    public class ModPcController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modPcs = db.ModPcs.Include(m => m.Fabricante).Include(m => m.Fornecedor);
            return View(modPcs.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModPc modPc = db.ModPcs.Find(id);
            if (modPc == null)
            {
                return HttpNotFound();
            }
            return View(modPc);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModPcID,FabricanteID,Processador,Memoria,Modelo,FornecedorID")] ModPc modPc)
        {
            if (ModelState.IsValid)
            {
                db.ModPcs.Add(modPc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modPc.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modPc.FornecedorID);
            return View(modPc);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModPc modPc = db.ModPcs.Find(id);
            if (modPc == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modPc.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modPc.FornecedorID);
            return View(modPc);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModPcID,FabricanteID,Processador,Memoria,Modelo,FornecedorID")] ModPc modPc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modPc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modPc.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modPc.FornecedorID);
            return View(modPc);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModPc modPc = db.ModPcs.Find(id);
            if (modPc == null)
            {
                return HttpNotFound();
            }
            return View(modPc);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModPc modPc = db.ModPcs.Find(id);
            db.ModPcs.Remove(modPc);
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
