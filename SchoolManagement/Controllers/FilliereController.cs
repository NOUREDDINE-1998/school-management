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
    public class FilliereController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filliere
        public ActionResult Index()
        {
            return View(db.Fillieres.ToList());
        }

        // GET: Filliere/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            return View(filliere);
        }

        // GET: Filliere/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filliere/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle")] Filliere filliere)
        {
            if (ModelState.IsValid)
            {
                db.Fillieres.Add(filliere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filliere);
        }

        // GET: Filliere/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            return View(filliere);
        }

        // POST: Filliere/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle")] Filliere filliere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filliere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filliere);
        }

        // GET: Filliere/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filliere filliere = db.Fillieres.Find(id);
            if (filliere == null)
            {
                return HttpNotFound();
            }
            return View(filliere);
        }

        // POST: Filliere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filliere filliere = db.Fillieres.Find(id);
            db.Fillieres.Remove(filliere);
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
