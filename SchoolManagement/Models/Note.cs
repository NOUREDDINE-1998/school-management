using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Note
    {
        [Display(Name ="Numero de Note")]
        public int  Id { get; set; }
        public virtual Etudiant  Etudiant { get; set; }

        [Required]
        [Display(Name = "Numero d 'Etudiant")]
        public string EtudiantId { get; set; }

        public virtual Examen  Examen { get; set; }

        [Required]
        [Display(Name = "Numero d'Examen")]
        public int ExamenId { get; set; }

        [Required]
        [Display(Name = "Note d'Examen")]
        public float NoteExamen { get; set; }

        public string  Mention  { get; set; }

       


    }
}