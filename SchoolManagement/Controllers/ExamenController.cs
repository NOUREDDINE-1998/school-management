using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class ExamenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examen
        public ActionResult Index()
        {
            var examens = db.examens.Include(e => e.Classe).Include(e => e.Module);
            return View(examens.ToList());
        }

        // GET: Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.classes, "Id", "Libelle");
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Libelle");
            return View();
        }

        // POST: Examen/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeExamen,DateExam,ClasseId,ModuleId")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.examens.Add(examen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.classes, "Id", "Libelle", examen.ClasseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Libelle", examen.ModuleId);
            return View(examen);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.classes, "Id", "Libelle", examen.ClasseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Libelle", examen.ModuleId);
            return View(examen);
        }

        // POST: Examen/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeExamen,DateExam,ClasseId,ModuleId")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.classes, "Id", "Libelle", examen.ClasseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Libelle", examen.ModuleId);
            return View(examen);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen examen = db.examens.Find(id);
            db.examens.Remove(examen);
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
