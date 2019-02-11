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
    public class ImpressorasController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var impressoras = db.Impressoras.Include(i => i.Funcionario).Include(i => i.Plaqueta).Include(i => i.ModImpressora);
            return View(impressoras.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressoras.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            return View(impressora);
        }

        
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            ViewBag.ModImpressoraID = new SelectList(db.ModImpressoras, "ModImpressoraID", "Modelo");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImpressoraID,FuncionarioID,ModImpressoraID,PlaquetaID")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                db.Impressoras.Add(impressora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", impressora.FuncionarioID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", impressora.PlaquetaID);
            ViewBag.ModImpressoraID = new SelectList(db.ModImpressoras, "ModImpressoraID", "Modelo", impressora.ModImpressoraID);
            return View(impressora);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressoras.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", impressora.FuncionarioID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", impressora.PlaquetaID);
            ViewBag.ModImpressoraID = new SelectList(db.ModImpressoras, "ModImpressoraID", "Modelo", impressora.ModImpressoraID);
            return View(impressora);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImpressoraID,FuncionarioID,ModImpressoraID,PlaquetaID")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impressora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", impressora.FuncionarioID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", impressora.PlaquetaID);
            ViewBag.ModImpressoraID = new SelectList(db.ModImpressoras, "ModImpressoraID", "Modelo", impressora.ModImpressoraID);
            return View(impressora);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressoras.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            return View(impressora);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Impressora impressora = db.Impressoras.Find(id);
            db.Impressoras.Remove(impressora);
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
