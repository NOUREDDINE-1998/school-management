using SchoolManagement.Models;
using SchoolManagement.ViesModels;
using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace SchoolManagement.Controllers
{
    public class EtudiantController : Controller
    {
        private ApplicationDbContext _db;
        public EtudiantController()
        {
            _db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
         }

        //----------------------------------------------------------------------------------------------------------------------
        // GET: Etudiant
        [Authorize]
        public ActionResult Index()
        {
            var etudiants = _db.Etudiants.Include(c => c.Classe).ToList();
            if (User.IsInRole("canManageEtudiant"))
                return View("Index", etudiants);

            return View("Index1",etudiants);
        }
        //-----------------------------------------------------------------------------------------------------------------------
        //Etudiant/Afficher/id
        [Authorize(Roles = "canManageEtudiant")]
        public ActionResult Afficher(string id)
        {
            if (ViewBag.inscId == null)
            {
                ViewBag.inscId = _db.Inscriptions.Single(e => e.EtudiantId == id).Id;
                if (ViewBag.inscId == null)
                {
                    ViewBag.inscId = "pas encore inscrit(e)";
                }
            }
            var etudiant = _db.Etudiants.Include(e=>e.Inscriptions).SingleOrDefault(c => c.Id == id);
            
            if (etudiant.Photo==null || etudiant.Photo == "" )
            {
                etudiant.Photo = "~/Images/download (3)214520257.jpg";
            }
            return View("Afficher",etudiant) ;
        }
        //--------------------------------------------------------------------------------------------------------------------------
        //Etudiant/edit/id
        public ActionResult edit(string id)
        {
            var etudiantAjouter = _db.Etudiants.SingleOrDefault(c => c.Id == id);
            var viewModel = new EtudiantViewModel
            {

                Nom = etudiantAjouter.Nom,
                Prenom = etudiantAjouter.Prenom,
                file = etudiantAjouter.file,
                Photo = etudiantAjouter.Photo,
                Date_Nai_Etu = etudiantAjouter.Date_Nai_Etu,
                Adresse = etudiantAjouter.Adresse,
                ClasseId = etudiantAjouter.ClasseId,
                Email = etudiantAjouter.Email,
                Tel = etudiantAjouter.Tel,
                Sexe = etudiantAjouter.Sexe,
                Classes = _db.classes.ToList(),
                
        };
            return View("MODIFIER", viewModel);
        }


        //----------------------------------------------------------------------------------------------------------------------------
        public ActionResult nouveau()
        {
            var Classe = _db.classes.ToList();
            var etudiantAjouter = new Etudiant();
            var viewModel = new EtudiantViewModel
            {

                Id = etudiantAjouter.Id,
                Nom = etudiantAjouter.Nom,
                Prenom = etudiantAjouter.Prenom,
                file = etudiantAjouter.file,
                Photo = etudiantAjouter.Photo,
                Date_Nai_Etu = etudiantAjouter.Date_Nai_Etu,
                Adresse = etudiantAjouter.Adresse,
                ClasseId = etudiantAjouter.ClasseId,
                Email = etudiantAjouter.Email,
                Tel = etudiantAjouter.Tel,
                Sexe = etudiantAjouter.Sexe,
                Classes = Classe

            };

            return View ("Ajouter", viewModel);
        }
        //========================================================================================
        //etudiant/Ajouter
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ajouter(Etudiant etudiantAjouter)
       {
            
            var count = _db.Etudiants.Count(e => e.Id == etudiantAjouter.Id);

            if (_db.Etudiants.Any(e => e.Tel == etudiantAjouter.Tel))
            {
                ModelState.AddModelError("Tel","ce numero de telephone est déja existe!!!");
             
            }
            if (_db.Etudiants.Any(e => e.Email == etudiantAjouter.Email))
            {
                
                ModelState.AddModelError("Email", "cet Email est déja existe!!!");
            }

            if (!ModelState.IsValid)
            {

                var viewModel = new EtudiantViewModel
                {
                    Id = etudiantAjouter.Id,
                    Nom = etudiantAjouter.Nom,
                    Prenom=etudiantAjouter.Prenom,
                    file=etudiantAjouter.file,
                    Photo=etudiantAjouter.Photo,
                    Date_Nai_Etu=etudiantAjouter.Date_Nai_Etu,
                    Adresse=etudiantAjouter.Adresse,
                    ClasseId=etudiantAjouter.ClasseId,
                    Email=etudiantAjouter.Email,
                    Tel=etudiantAjouter.Tel,
                    Sexe=etudiantAjouter.Sexe,

                    Classes = _db.classes.ToList()

                };

                return View("Ajouter", viewModel);
            }
            // UPLOAD IMAGE 
           
            else if(count==0)
            {

                if (etudiantAjouter.file != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(etudiantAjouter.file.FileName);
                    string extension = Path.GetExtension(etudiantAjouter.file.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    etudiantAjouter.Photo = "~/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    etudiantAjouter.file.SaveAs(filename);
                }

                if (etudiantAjouter.Photo == null || etudiantAjouter.Photo == "")
                {
                    etudiantAjouter.Photo = "~/Images/download (3)214520257.jpg";
                }

                _db.Etudiants.Add(etudiantAjouter);
                _db.SaveChanges();
            }         
                              
            
            return RedirectToAction("Index", "Etudiant");
        }

        //-----------------------------------------------------------------------------------------------------
        //ETUDIANT/MODIFIER
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult MODIFIER(Etudiant etudiant)
        {
          //  etudiant.Photo = etudiant.file.ToString();
            if (!ModelState.IsValid)
            {
                var viewModel = new EtudiantViewModel
                {
                    Id = etudiant.Id,
                    Nom = etudiant.Nom,
                    Prenom = etudiant.Prenom,
                    file = etudiant.file,
                    Photo = etudiant.Photo,
                    Date_Nai_Etu = etudiant.Date_Nai_Etu,
                    Adresse = etudiant.Adresse,
                    ClasseId = etudiant.ClasseId,
                    Email = etudiant.Email,
                    Tel = etudiant.Tel,
                    Sexe = etudiant.Sexe,

                    Classes = _db.classes.ToList()

                };
                return View("MODIFIER", viewModel);
            }

            // UPLOAD IMAGE 

            var etudiantInDB = _db.Etudiants.Single(e => e.Id == etudiant.Id);

            if (etudiant.file != null)
            {
                string filename = Path.GetFileNameWithoutExtension(etudiant.file.FileName);
                string extension = Path.GetExtension(etudiant.file.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                etudiant.Photo = "~/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                etudiant.file.SaveAs(filename);
            }
           
            if (etudiant.Photo == null)
            {
                etudiant.Photo = etudiantInDB.Photo;
            }
            
            //compare data in form with in database

            etudiantInDB.Nom = etudiant.Nom;
                etudiantInDB.Prenom = etudiant.Prenom;
                etudiantInDB.Date_Nai_Etu = etudiant.Date_Nai_Etu;
                etudiantInDB.Email = etudiant.Email;
                etudiantInDB.Tel = etudiant.Tel;
                etudiantInDB.Sexe = etudiant.Sexe;
                etudiantInDB.Adresse = etudiant.Adresse;
                etudiantInDB.Photo = etudiant.Photo;
            etudiantInDB.ClasseId = etudiant.ClasseId;
            
            _db.SaveChanges();

            return RedirectToAction("Index","Etudiant");
        }
        //==================================================================================================
        public ActionResult Supprimer()
        {
           return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Supprimer( string id )
        //{
        //    Etudiant etudiant = _db.Etudiants.FirstOrDefault(e=>e.Id==id);
        //    if (etudiant != null)
        //    {
        //        _db.Etudiants.Remove(etudiant);
        //        _db.SaveChanges();

        //        return RedirectToAction("Index", "Etudiant");
        //    }
        //    else
        //        return View();

        //}
        //================================================
        // I COMMENTED THOSE METHODES BECAUSE OF THE UPDATE METHODE DOESN'T WORK WITH THAT
        // methode of unique 

        // for tel
        //public JsonResult IsTelUnique(string tel)
        //{
            
        //    return Json(!_db.Etudiants.Any(e => e.Tel == tel),JsonRequestBehavior.AllowGet);
        //}

        //// for email
        //public JsonResult IsEmailUnique(string email)
        //{
        //    return Json(!_db.Etudiants.Any(e => e.Email == email), JsonRequestBehavior.AllowGet);
        //}

       
    }
}