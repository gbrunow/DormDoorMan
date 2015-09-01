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
        [Key]
        public int Id { get; set; }

        public int GuestID { get; set; }
        
        [ForeignKey("GuestID")]
        [Required, Display(Name = "Hóspede Responsável")]
        public virtual Guest Guest { get; set; }

        [Required, Display(Name = "Número de Hóspedes")]
        public int GuestNumber { get; set; }
        public int PaymentID { get; set; }
        
        [ForeignKey("PaymentID")]
        [Display(Name = "Pagamento")]
        public virtual Payment Payment { get; set; }
    }
}