 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolManagement.DTOs
{
    public class EtudiantsDTO
    {
        [Required]
        [Display(Name = "N° CNIE")]
        public string Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Date_Nai_Etu { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Tel { get; set; }

        [Required]
        public string Sexe { get; set; }

        public string Photo { get; set; }


        [NotMapped]
        public HttpPostedFileBase file { get; set; }

        public int? ClasseId { get; set; }


   
    }
}