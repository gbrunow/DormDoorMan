using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Resident : Person
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Quarto")]
        public int Room { get; set; }

        [Display(Name = "Visitantes")]
        public ICollection<Visit> Visits { get; set; }

        [Display(Name = "Encomendas")]
        public ICollection<Package> Packages { get; set; }

        [Display(Name = "Pessoas de Confiança")]
        public ICollection<Resident> TrustedPeople { get; set; }
    }
}