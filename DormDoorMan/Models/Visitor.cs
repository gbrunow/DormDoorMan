using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Visitor : Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Visitas")]
        public ICollection<Visit> Visits { get; set; }
    }
}