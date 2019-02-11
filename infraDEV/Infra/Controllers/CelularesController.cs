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
    public class CelularesController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var celulars = db.Celulars.Include(c => c.Funcionario).Include(c => c.ModTelefone);
            return View(celulars.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulars.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(celular);
        }

       
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CelularID,ModTelefoneID,FuncionarioID,Imei,Serial,Numero")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                db.Celulars.Add(celular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", celular.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", celular.ModTelefoneID);
            return View(celular);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulars.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", celular.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", celular.ModTelefoneID);
            return View(celular);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CelularID,ModTelefoneID,FuncionarioID,Imei,Serial,Numero")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", celular.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", celular.ModTelefoneID);
            return View(celular);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulars.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(celular);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celular celular = db.Celulars.Find(id);
            db.Celulars.Remove(celular);
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
