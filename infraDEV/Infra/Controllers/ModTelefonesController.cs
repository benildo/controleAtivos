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
    public class ModTelefonesController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modTelefones = db.ModTelefones.Include(m => m.Fabricante).Include(m => m.Fornecedor);
            return View(modTelefones.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTelefone modTelefone = db.ModTelefones.Find(id);
            if (modTelefone == null)
            {
                return HttpNotFound();
            }
            return View(modTelefone);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModTelefoneID,Modelo,FabricanteID,FornecedorID")] ModTelefone modTelefone)
        {
            if (ModelState.IsValid)
            {
                db.ModTelefones.Add(modTelefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTelefone.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTelefone.FornecedorID);
            return View(modTelefone);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTelefone modTelefone = db.ModTelefones.Find(id);
            if (modTelefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTelefone.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTelefone.FornecedorID);
            return View(modTelefone);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModTelefoneID,Modelo,FabricanteID,FornecedorID")] ModTelefone modTelefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modTelefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTelefone.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTelefone.FornecedorID);
            return View(modTelefone);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTelefone modTelefone = db.ModTelefones.Find(id);
            if (modTelefone == null)
            {
                return HttpNotFound();
            }
            return View(modTelefone);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModTelefone modTelefone = db.ModTelefones.Find(id);
            db.ModTelefones.Remove(modTelefone);
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
