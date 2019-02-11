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
    public class ModTecladosController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var modTecladoes = db.ModTecladoes.Include(m => m.Fabricante).Include(m => m.Fornecedor);
            return View(modTecladoes.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTeclado modTeclado = db.ModTecladoes.Find(id);
            if (modTeclado == null)
            {
                return HttpNotFound();
            }
            return View(modTeclado);
        }

       
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModTecladoID,FornecedorID,FabricanteID,Modelo")] ModTeclado modTeclado)
        {
            if (ModelState.IsValid)
            {
                db.ModTecladoes.Add(modTeclado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTeclado.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTeclado.FornecedorID);
            return View(modTeclado);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTeclado modTeclado = db.ModTecladoes.Find(id);
            if (modTeclado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTeclado.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTeclado.FornecedorID);
            return View(modTeclado);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModTecladoID,FornecedorID,FabricanteID,Modelo")] ModTeclado modTeclado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modTeclado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", modTeclado.FabricanteID);
            ViewBag.FornecedorID = new SelectList(db.Fornecedors, "FornecedorID", "Nome", modTeclado.FornecedorID);
            return View(modTeclado);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModTeclado modTeclado = db.ModTecladoes.Find(id);
            if (modTeclado == null)
            {
                return HttpNotFound();
            }
            return View(modTeclado);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModTeclado modTeclado = db.ModTecladoes.Find(id);
            db.ModTecladoes.Remove(modTeclado);
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
