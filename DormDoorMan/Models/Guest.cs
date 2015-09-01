using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Guest : Person
    {
        public Guest()
        {
            this.Hostings = new HashSet<Hosting>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Hospedagens")]
        public virtual ICollection<Hosting> Hostings { get; set; }

        [Display(Name = "Reservas")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}