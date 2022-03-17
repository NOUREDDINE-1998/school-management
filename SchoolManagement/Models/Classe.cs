using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Classe
    {
        [Display(Name = "Numero  de la Classe")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom de Classe")]
        public string Libelle { get; set; }

        public virtual ICollection<Etudiant> Etudiants { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

    }
}