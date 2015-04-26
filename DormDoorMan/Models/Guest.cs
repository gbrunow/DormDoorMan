using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Guest : Person
    {
        [Display(Name = "Hospedagens")]
        public virtual ICollection<Hosting> Hostings { get; set; }
        [Display(Name = "Reservas")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}