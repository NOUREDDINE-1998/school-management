using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Filliere
    {
        [Display(Name = "Numero de la Filliére")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Filliére")]
        public string Libelle { get; set; }


        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}