using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Inscription
    {
        [Display(Name ="Numero d'Inscription")]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateInscription { get; set; }  //by default getdate()

        [Required]
        public string AnneeScolaire { get; set; }// by default date.Now.year - date.Now.year+1

        [Required]
        [Display(Name = "Niveau de Scolarité")]
        public string NiveauScolarite { get; set; }

        public string Categorie { get; set; }

        [Required]
        [Display(Name = "Niveau de Formation")]
        public string NiveauFormation { get; set; }


        public virtual Etudiant Etudiant { get; set; }
        public string EtudiantId { get; set; }

        public virtual Filliere Filliere { get; set; }
        public int FilliereId { get; set; }


    }
}