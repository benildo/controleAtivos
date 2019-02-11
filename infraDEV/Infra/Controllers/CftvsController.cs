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
    public class CftvsController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        
        public ActionResult Index()
        {
            var cftvs = db.Cftvs.Include(c => c.Plaqueta).Include(c => c.ModCftv);
            return View(cftvs.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cftv cftv = db.Cftvs.Find(id);
            if (cftv == null)
            {
                return HttpNotFound();
            }
            return View(cftv);
        }

        
        public ActionResult Create()
        {
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            ViewBag.ModCftvID = new SelectList(db.ModCftvs, "ModCftvID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CftvID,ModCftvID,PlaquetaID,Local")] Cftv cftv)
        {
            if (ModelState.IsValid)
            {
                db.Cftvs.Add(cftv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cftv.PlaquetaID);
            ViewBag.ModCftvID = new SelectList(db.ModCftvs, "ModCftvID", "Nome", cftv.ModCftvID);
            return View(cftv);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cftv cftv = db.Cftvs.Find(id);
            if (cftv == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cftv.PlaquetaID);
            ViewBag.ModCftvID = new SelectList(db.ModCftvs, "ModCftvID", "Nome", cftv.ModCftvID);
            return View(cftv);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CftvID,ModCftvID,PlaquetaID,Local")] Cftv cftv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cftv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", cftv.PlaquetaID);
            ViewBag.ModCftvID = new SelectList(db.ModCftvs, "ModCftvID", "Nome", cftv.ModCftvID);
            return View(cftv);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cftv cftv = db.Cftvs.Find(id);
            if (cftv == null)
            {
                return HttpNotFound();
            }
            return View(cftv);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cftv cftv = db.Cftvs.Find(id);
            db.Cftvs.Remove(cftv);
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
