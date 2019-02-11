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
    public class WindowsController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var windows = db.Windows.Include(w => w.Funcionario).Include(w => w.ModSoftware);
            return View(windows.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Window window = db.Windows.Find(id);
            if (window == null)
            {
                return HttpNotFound();
            }
            return View(window);
        }

        
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModSoftwareID = new SelectList(db.ModSoftwares, "ModSoftwareID", "Modelo");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WindowsID,ModSoftwareID,Serial,FuncionarioID,Ativado")] Window window)
        {
            if (ModelState.IsValid)
            {
                db.Windows.Add(window);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", window.FuncionarioID);
            ViewBag.ModSoftwareID = new SelectList(db.ModSoftwares, "ModSoftwareID", "Modelo", window.ModSoftwareID);
            return View(window);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Window window = db.Windows.Find(id);
            if (window == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", window.FuncionarioID);
            ViewBag.ModSoftwareID = new SelectList(db.ModSoftwares, "ModSoftwareID", "Modelo", window.ModSoftwareID);
            return View(window);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WindowsID,ModSoftwareID,Serial,FuncionarioID,Ativado")] Window window)
        {
            if (ModelState.IsValid)
            {
                db.Entry(window).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", window.FuncionarioID);
            ViewBag.ModSoftwareID = new SelectList(db.ModSoftwares, "ModSoftwareID", "Modelo", window.ModSoftwareID);
            return View(window);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Window window = db.Windows.Find(id);
            if (window == null)
            {
                return HttpNotFound();
            }
            return View(window);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Window window = db.Windows.Find(id);
            db.Windows.Remove(window);
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
