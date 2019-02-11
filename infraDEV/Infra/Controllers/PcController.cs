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
    public class PcController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var pcs = db.Pcs.Include(p => p.Funcionario).Include(p => p.ModPc).Include(p => p.Plaqueta);
            return View(pcs.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pc pc = db.Pcs.Find(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            return View(pc);
        }

       
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModPcID = new SelectList(db.ModPcs, "ModPcID", "Modelo");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PcID,FuncionarioID,ModPcID,NomePc,Série,PlaquetaID,Auditorado,DataCompra,Preço")] Pc pc)
        {
            if (ModelState.IsValid)
            {
                db.Pcs.Add(pc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", pc.FuncionarioID);
            ViewBag.ModPcID = new SelectList(db.ModPcs, "ModPcID", "Modelo", pc.ModPcID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", pc.PlaquetaID);
            return View(pc);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pc pc = db.Pcs.Find(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", pc.FuncionarioID);
            ViewBag.ModPcID = new SelectList(db.ModPcs, "ModPcID", "Modelo", pc.ModPcID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", pc.PlaquetaID);
            return View(pc);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PcID,FuncionarioID,ModPcID,NomePc,Série,PlaquetaID,Auditorado,DataCompra,Preço")] Pc pc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", pc.FuncionarioID);
            ViewBag.ModPcID = new SelectList(db.ModPcs, "ModPcID", "Modelo", pc.ModPcID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", pc.PlaquetaID);
            return View(pc);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pc pc = db.Pcs.Find(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            return View(pc);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pc pc = db.Pcs.Find(id);
            db.Pcs.Remove(pc);
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
