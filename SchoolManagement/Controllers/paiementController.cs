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
    public class paiementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: paiement
        public ActionResult Index()
        {
            var paiements = db.Paiements.Include(p => p.Etudiant);
            return View(paiements.ToList());
        }

        // GET: paiement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // GET: paiement/Create
        public ActionResult Create()
        {
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id");
            return View();
        }

        // POST: paiement/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EtudiantId,TypeReglement,TypePaiement,DureeEnMois,Montant,DatePaiment")] paiement paiement)
        {
            if (ModelState.IsValid)
            {
                paiement.DatePaiment = DateTime.Parse(DateTime.Now.ToShortDateString());
                db.Paiements.Add(paiement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", paiement.EtudiantId);
            return View(paiement);
        }

        // GET: paiement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", paiement.EtudiantId);
            return View(paiement);
        }

        // POST: paiement/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EtudiantId,TypeReglement,TypePaiement,DureeEnMois,Montant,DatePaiment")] paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paiement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Id", paiement.EtudiantId);
            return View(paiement);
        }

        // GET: paiement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
            return View(paiement);
        }

        // POST: paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paiement paiement = db.Paiements.Find(id);
            db.Paiements.Remove(paiement);
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
