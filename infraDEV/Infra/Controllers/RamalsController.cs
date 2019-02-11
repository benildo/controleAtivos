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
    public class RamalsController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IpSortParm = String.IsNullOrEmpty(sortOrder) ? "ip_desc" : "";
            ViewBag.NumeroSortParm = sortOrder == "numero" ? "numero_desc" : "numero";

            var ramals = from r in db.Ramals
                         select r;

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



            if (!String.IsNullOrEmpty(searchString))
            {
                ramals = ramals.Where(r => r.Funcionario.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ip_desc":
                    ramals = ramals.OrderByDescending(r => r.Ip);
                    break;
                case "numero":
                    ramals = ramals.OrderBy(r => r.Numero);
                    break;
                case "numero_desc":
                    ramals = ramals.OrderByDescending(r => r.Numero);
                    break;
                default:
                    ramals = ramals.OrderBy(r => r.Ip);
                    break;

            }
            int pageNumber = (page ?? 1);
            return View(ramals.ToList());
            //var ramals = db.Ramals.Include(r => r.Funcionario).Include(r => r.ModTelefone);
            //return View(ramals.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ramal ramal = db.Ramals.Find(id);
            if (ramal == null)
            {
                return HttpNotFound();
            }
            return View(ramal);
        }

       
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RamalID,FuncionarioID,ModTelefoneID,Mac,Ip,Numero")] Ramal ramal)
        {
            if (ModelState.IsValid)
            {
                db.Ramals.Add(ramal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", ramal.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", ramal.ModTelefoneID);
            return View(ramal);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ramal ramal = db.Ramals.Find(id);
            if (ramal == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", ramal.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", ramal.ModTelefoneID);
            return View(ramal);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RamalID,FuncionarioID,ModTelefoneID,Mac,Ip,Numero")] Ramal ramal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", ramal.FuncionarioID);
            ViewBag.ModTelefoneID = new SelectList(db.ModTelefones, "ModTelefoneID", "Modelo", ramal.ModTelefoneID);
            return View(ramal);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ramal ramal = db.Ramals.Find(id);
            if (ramal == null)
            {
                return HttpNotFound();
            }
            return View(ramal);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ramal ramal = db.Ramals.Find(id);
            db.Ramals.Remove(ramal);
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
