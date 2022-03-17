using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Module
    {
        [Display(Name = "Numero du Module")]
        public int  Id { get; set; }

        [Required]
        [Display(Name = "Nom du Module")]
        public string  Libelle { get; set; }

        [Required]
        public byte  Coefficient { get; set; }

        [Required]
        [Display(Name = "Total des Heures")]
        public byte TotalHeures { get; set; }


        public virtual ICollection<Classe>  Classes { get; set; }
    }
}