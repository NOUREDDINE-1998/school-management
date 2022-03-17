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
    public class InscriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscription
        public ActionResult Index()
        {
            var inscriptions = db.Inscriptions.Include(i => i.Etudiant).Include(i => i.Filliere);
            return View(inscriptions.ToList());
      
        }

        // GET: Inscription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // GET: Inscription/Create
        public ActionResult Create()
        {
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id");
            ViewBag.FilliereId = new SelectList(db.Fillieres, "Id", "Libelle");
            return View();
        }

        // POST: Inscription/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateInscription,AnneeScolaire,NiveauScolarite,Categorie,NiveauFormation,EtudiantId,FilliereId")] Inscription inscription)
        {
            inscription.DateInscription = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (db.Inscriptions.Any(e => e.EtudiantId == inscription.EtudiantId && e.DateInscription.Year == inscription.DateInscription.Year))
            {
                ModelState.AddModelError("EtudiantId", "cet etudiant est deja inscrit");

            }
            if (ModelState.IsValid)
            {
               
                db.Inscriptions.Add(inscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", inscription.EtudiantId);
            ViewBag.FilliereId = new SelectList(db.Fillieres, "Id", "Libelle", inscription.FilliereId);
            return View(inscription);
        }

        // GET: Inscription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", inscription.EtudiantId);
            ViewBag.FilliereId = new SelectList(db.Fillieres, "Id", "Libelle", inscription.FilliereId);
            return View(inscription);
        }

        // POST: Inscription/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateInscription,AnneeScolaire,NiveauScolarite,Categorie,NiveauFormation,EtudiantId,FilliereId")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", inscription.EtudiantId);
            ViewBag.FilliereId = new SelectList(db.Fillieres, "Id", "Libelle", inscription.FilliereId);
            return View(inscription);
        }

        // GET: Inscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscription inscription = db.Inscriptions.Find(id);
            db.Inscriptions.Remove(inscription);
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
