using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using SchoolManagement.Models;
using AutoMapper;
using SchoolManagement.DTOs;

namespace SchoolManagement.Controllers.API
{
    public class EtudiantsController : ApiController
    {
        private ApplicationDbContext _db;
        public EtudiantsController()
        {
            _db = new ApplicationDbContext();
        }

        //GET /API/ETUDIANTS
        public IHttpActionResult GetEtudiants()
        {
           
            var etudiantsDTO=_db.Etudiants.ToList().Select(Mapper.Map<Etudiant, EtudiantsDTO>);
            return Ok(etudiantsDTO);
        }

        //GET /API/ETUDIANTS/1
        public IHttpActionResult GetEtudiant(string id)
        {
            var etudiant = _db.Etudiants.SingleOrDefault(e => e.Id == id);
            if (etudiant == null)
                return NotFound();

            return Ok(Mapper.Map<Etudiant,EtudiantsDTO>(etudiant));
        }

        //POST/API/ETUDIANT

        [HttpPost]
        public IHttpActionResult AjouterEtudiant(EtudiantsDTO etudiantsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();            }
            var etudiant = Mapper.Map<EtudiantsDTO, Etudiant>(etudiantsDTO);
            _db.Etudiants.Add(etudiant);
            _db.SaveChanges();
            etudiantsDTO.Id = etudiant.Id;

            return Created(new Uri(Request.RequestUri+"/"+etudiant.Id),etudiantsDTO);    
        }

        //POST/API/ETUDIANT

        [HttpPut]
        public void ModifierEtudiant(EtudiantsDTO etudiantsDTO, string id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var etudiantInDB = _db.Etudiants.SingleOrDefault(e => e.Id == id);
            if(etudiantInDB==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(etudiantsDTO, etudiantInDB);

            _db.SaveChanges();
       
        }

        //DELETE/API/ETUDIANT/1

        [HttpDelete]
        public IHttpActionResult SupprimerEtudiant(string id)
        {
            var etudiantInDB = _db.Etudiants.SingleOrDefault(e => e.Id == id);
            if (etudiantInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _db.Etudiants.Remove(etudiantInDB);
            _db.SaveChanges();
            return Ok();
        }
    }
}
