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
    public class CadeirasController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var cadeiras = db.Cadeiras.Include(c => c.Funcionario).Include(c => c.ModMovel).Include(c => c.Plaqueta);
            return View(cadeiras.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadeira cadeira = db.Cadeiras.Find(id);
            if (cadeira == null)
            {
                return HttpNotFound();
            }
            return View(cadeira);
        }

        
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModModelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CadeiraID,FuncionarioID,ModModelID,PlaquetaID,Data")] Cadeira cadeira)
        {
            if (ModelState.IsValid)
            {
                db.Cadeiras.Add(cadeira);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", cadeira.FuncionarioID);
            ViewBag.ModModelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", cadeira.ModModelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cadeira.PlaquetaID);
            return View(cadeira);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadeira cadeira = db.Cadeiras.Find(id);
            if (cadeira == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", cadeira.FuncionarioID);
            ViewBag.ModModelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", cadeira.ModModelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cadeira.PlaquetaID);
            return View(cadeira);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CadeiraID,FuncionarioID,ModModelID,PlaquetaID,Data")] Cadeira cadeira)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadeira).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", cadeira.FuncionarioID);
            ViewBag.ModModelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", cadeira.ModModelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cadeira.PlaquetaID);
            return View(cadeira);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadeira cadeira = db.Cadeiras.Find(id);
            if (cadeira == null)
            {
                return HttpNotFound();
            }
            return View(cadeira);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadeira cadeira = db.Cadeiras.Find(id);
            db.Cadeiras.Remove(cadeira);
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
