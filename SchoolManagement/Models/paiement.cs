using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class paiement
    {
        public int Id { get; set; }

        public virtual Etudiant Etudiant { get; set; }

        [Required]
        public virtual string EtudiantId { get; set; }

        [Required]
        public string TypeReglement { get; set; }


        public string TypePaiement { get; set; }

        [Required]
        public byte DureeEnMois  { get; set; }

        [Required]
        public decimal Montant { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime DatePaiment { get; set; }




    }
}