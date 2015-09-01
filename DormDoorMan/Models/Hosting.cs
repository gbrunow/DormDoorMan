using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Hosting
    {
        public Hosting()
        {
            this.Guests = new HashSet<Guest>();
            this.Payments = new HashSet<Payment>();
        }

        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Hóspedes")]
        public virtual ICollection<Guest> Guests { get; set; }

        [Required, Display(Name = "Pagamentos")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}