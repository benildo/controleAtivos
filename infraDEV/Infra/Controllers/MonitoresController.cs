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
    public class MonitoresController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PlaquetaSortParm = sortOrder == "Plaqueta" ? "plaqueta_desc" : "Plaqueta";

            var monitors = from m in db.Monitors
                           select m;         
            
            if (!String.IsNullOrEmpty(searchString))
            {
                
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            

            if(!String.IsNullOrEmpty(searchString))
            {
                monitors = monitors.Where(m => m.Funcionario.Nome.Contains(searchString) || m.Fabricante.Nome.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    monitors = monitors.OrderByDescending(m => m.Funcionario.Nome);
                    break;
                case "Plaqueta":
                    monitors = monitors.OrderBy(m => m.PlaquetaID);
                    break;
                case "plaqueta_desc":
                    monitors = monitors.OrderByDescending(m => m.PlaquetaID);
                    break;
                default:
                    monitors = monitors.OrderBy(m => m.Funcionario.Nome);
                    break;                                   
                
            }           
            int pageNumber = (page ?? 1);
            return View(monitors.ToList());
            



            //var monitors = db.Monitors.Include(m => m.Fabricante).Include(m => m.Funcionario).Include(m => m.ModMonitor).Include(m => m.Plaqueta);
            //return View(monitors.ToList());
        }        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.Modelo = new SelectList(db.ModMonitors, "ModMonitorID", "Modelo");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonitorID,FuncionarioID,FabricanteID,Modelo,PlaquetaID")] Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                db.Monitors.Add(monitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", monitor.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", monitor.FuncionarioID);
            ViewBag.Modelo = new SelectList(db.ModMonitors, "ModMonitorID", "Modelo", monitor.Modelo);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", monitor.PlaquetaID);
            return View(monitor);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", monitor.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", monitor.FuncionarioID);
            ViewBag.Modelo = new SelectList(db.ModMonitors, "ModMonitorID", "Modelo", monitor.Modelo);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", monitor.PlaquetaID);
            return View(monitor);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonitorID,FuncionarioID,FabricanteID,Modelo,PlaquetaID")] Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", monitor.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", monitor.FuncionarioID);
            ViewBag.Modelo = new SelectList(db.ModMonitors, "ModMonitorID", "Modelo", monitor.Modelo);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", monitor.PlaquetaID);
            return View(monitor);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monitor monitor = db.Monitors.Find(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monitor monitor = db.Monitors.Find(id);
            db.Monitors.Remove(monitor);
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
