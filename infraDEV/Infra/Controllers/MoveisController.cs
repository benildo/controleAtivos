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
    public class MoveisController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var moveis = db.Moveis.Include(m => m.Funcionario).Include(m => m.ModMovel).Include(m => m.Plaqueta);
            return View(moveis.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movei movei = db.Moveis.Find(id);
            if (movei == null)
            {
                return HttpNotFound();
            }
            return View(movei);
        }

        
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.MovelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovelID,FuncionarioID,Modelo,PlaquetaID")] Movei movei)
        {
            if (ModelState.IsValid)
            {
                db.Moveis.Add(movei);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", movei.FuncionarioID);
            ViewBag.MovelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", movei.MovelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", movei.PlaquetaID);
            return View(movei);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movei movei = db.Moveis.Find(id);
            if (movei == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", movei.FuncionarioID);
            ViewBag.MovelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", movei.MovelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", movei.PlaquetaID);
            return View(movei);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovelID,FuncionarioID,Modelo,PlaquetaID")] Movei movei)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movei).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", movei.FuncionarioID);
            ViewBag.MovelID = new SelectList(db.ModMovels, "ModMovelID", "Modelo", movei.MovelID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", movei.PlaquetaID);
            return View(movei);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movei movei = db.Moveis.Find(id);
            if (movei == null)
            {
                return HttpNotFound();
            }
            return View(movei);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movei movei = db.Moveis.Find(id);
            db.Moveis.Remove(movei);
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
