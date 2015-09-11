using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DormDoorMan.Models
{
    public class Visitor : Person
    {
        public Visitor()
        {
            this.Visits = new HashSet<Visit>();
        }
        [Display(Name = "Visitas")]
        public ICollection<Visit> Visits { get; set; }

    }
}