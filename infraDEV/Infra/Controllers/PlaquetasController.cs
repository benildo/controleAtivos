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
    public class PlaquetasController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            return View(db.Plaquetas.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaqueta plaqueta = db.Plaquetas.Find(id);
            if (plaqueta == null)
            {
                return HttpNotFound();
            }
            return View(plaqueta);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaquetaID,Ativada")] Plaqueta plaqueta)
        {
            if (ModelState.IsValid)
            {
                db.Plaquetas.Add(plaqueta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plaqueta);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaqueta plaqueta = db.Plaquetas.Find(id);
            if (plaqueta == null)
            {
                return HttpNotFound();
            }
            return View(plaqueta);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaquetaID,Ativada")] Plaqueta plaqueta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plaqueta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plaqueta);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaqueta plaqueta = db.Plaquetas.Find(id);
            if (plaqueta == null)
            {
                return HttpNotFound();
            }
            return View(plaqueta);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plaqueta plaqueta = db.Plaquetas.Find(id);
            db.Plaquetas.Remove(plaqueta);
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
