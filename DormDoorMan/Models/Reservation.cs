using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Reservation : Schedule
    {
        [ForeignKey("GuestID")]
        public int GuestID { get; set; }
        [Required, Display(Name = "Hóspede Responsável")]
        public virtual Guest Guest { get; set; }
        [Required, Display(Name = "Número de Hóspedes")]
        public int GuestNumber { get; set; }
        [ForeignKey("PaymentID")]
        public int PaymentID { get; set; }
        [Display(Name = "Pagamento")]
        public virtual Payment Payment { get; set; }
    }
}