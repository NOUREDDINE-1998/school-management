using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolManagement.ViesModels
{
    public class EtudiantViewModel
    {
        public IEnumerable<Classe> Classes { get; set; }

        [Required]
        [Display(Name = "N° CNIE")]
        public string Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }


        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date_Nai_Etu { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        // [Remote(action: "IsEmailUnique", controller: "Etudiant", HttpMethod = "POST", ErrorMessage = "cet email est deja existe")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        //[Remote(action:"IsTelUnique",controller:"Etudiant", HttpMethod = "POST", ErrorMessage ="ce numero de telephone est deja existe")]
        [StringLength(200)]
        public string Tel { get; set; }

        [Required]
        public string Sexe { get; set; }

        [Display(Name = "upload photo")]
        public string Photo { get; set; }


        [NotMapped]
        public HttpPostedFileBase file { get; set; }

        public virtual ICollection<Inscription> Inscriptions { get; set; }

        public virtual Classe Classe { get; set; }
        public int? ClasseId { get; set; }

        public virtual ICollection<Examen> Examens { get; set; }

        public virtual ICollection<paiement> Paiements { get; set; }



    }

}