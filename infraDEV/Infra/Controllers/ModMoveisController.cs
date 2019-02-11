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
    public class ModMoveisController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modMovels = db.ModMovels.Include(m => m.Fabricante).Include(m => m.Fornecedor);
            return View(modMovels.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMovel modMovel = db.ModMovels.Find(id);
            if (modMovel == null)
            {
                return HttpNotFound();
            }
            return View(modMovel);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModMovelID,Modelo,FabricanteID,Referencia,FornecedorID")] ModMovel modMovel)
        {
            if (ModelState.IsValid)
            {
                db.ModMovels.Add(modMovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMovel.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMovel.FornecedorID);
            return View(modMovel);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMovel modMovel = db.ModMovels.Find(id);
            if (modMovel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMovel.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMovel.FornecedorID);
            return View(modMovel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModMovelID,Modelo,FabricanteID,Referencia,FornecedorID")] ModMovel modMovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modMovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modMovel.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modMovel.FornecedorID);
            return View(modMovel);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModMovel modMovel = db.ModMovels.Find(id);
            if (modMovel == null)
            {
                return HttpNotFound();
            }
            return View(modMovel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModMovel modMovel = db.ModMovels.Find(id);
            db.ModMovels.Remove(modMovel);
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
