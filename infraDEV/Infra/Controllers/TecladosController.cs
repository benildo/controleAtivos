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
    public class TecladosController : Controller
    {
        private AtivosDBEntities db = new AtivosDBEntities();

        // GET: Teclados
        public ActionResult Index()
        {
            var tecladoes = db.Tecladoes.Include(t => t.Fabricante).Include(t => t.Funcionario).Include(t => t.ModTeclado).Include(t => t.Plaqueta);
            return View(tecladoes.ToList());
        }

        // GET: Teclados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Tecladoes.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // GET: Teclados/Create
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome");
            ViewBag.ModTecladoID = new SelectList(db.ModTecladoes, "ModTecladoID", "Modelo");
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID");
            return View();
        }

        // POST: Teclados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TecladoID,FuncionarioID,FabricanteID,ModTecladoID,PlaquetaID")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Tecladoes.Add(teclado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", teclado.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", teclado.FuncionarioID);
            ViewBag.ModTecladoID = new SelectList(db.ModTecladoes, "ModTecladoID", "Modelo", teclado.ModTecladoID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", teclado.PlaquetaID);
            return View(teclado);
        }

        // GET: Teclados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Tecladoes.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", teclado.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", teclado.FuncionarioID);
            ViewBag.ModTecladoID = new SelectList(db.ModTecladoes, "ModTecladoID", "Modelo", teclado.ModTecladoID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", teclado.PlaquetaID);
            return View(teclado);
        }

        // POST: Teclados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TecladoID,FuncionarioID,FabricanteID,ModTecladoID,PlaquetaID")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teclado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "IdFabricante", "Nome", teclado.FabricanteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "Nome", teclado.FuncionarioID);
            ViewBag.ModTecladoID = new SelectList(db.ModTecladoes, "ModTecladoID", "Modelo", teclado.ModTecladoID);
            ViewBag.PlaquetaID = new SelectList(db.Plaquetas, "PlaquetaID", "PlaquetaID", teclado.PlaquetaID);
            return View(teclado);
        }

        // GET: Teclados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Tecladoes.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // POST: Teclados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teclado teclado = db.Tecladoes.Find(id);
            db.Tecladoes.Remove(teclado);
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
