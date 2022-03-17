using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Examen
    {
        [Display(Name = "Numero d'Examen")]
        public int Id { get; set; }

        [Required]      
        public string  TypeExamen { get; set; }

        [Required]
        [Display(Name = "Date d'Examen")]
        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime ? DateExam { get; set; }

        public virtual Classe Classe { get; set; }

        [Display(Name = "Nom de la Classe")]
        public virtual int? ClasseId { get; set; }

        public virtual Module Module { get; set; }

        [Display(Name = "Nom du Module")]
        public virtual int? ModuleId { get; set; }

        public  ICollection<Etudiant> Etudiants { get; set; }
    }

    
}