using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Resident : Person
    {
        [Required, Display(Name = "Quarto")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Utilize apenas números.")]
        public string Room { get; set; }

        [Display(Name = "Visitantes")]
        public ICollection<Visit> Visits { get; set; }

        [Display(Name = "Encomendas")]
        public ICollection<Package> Packages { get; set; }

        [Display(Name = "Pessoas de Confiança")]
        public ICollection<Resident> TrustedPeople { get; set; }
    }
}