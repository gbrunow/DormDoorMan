using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Hosting
    {
        [Required, Display(Name = "Hóspedes")]
        public virtual ICollection<Guest> Guests { get; set; }
        [Required, Display(Name = "Pagamentos")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}