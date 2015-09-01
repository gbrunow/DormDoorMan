using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Valor Pago")]
        public double Value { get; set; }

        [Display(Name = "Comprovante")]
        public byte[] ProofOfPayment { get; set; }
        public int HostingID { get; set; }

        [ForeignKey("HostingID")]
        public virtual Hosting Hosting { get; set; }
    }
}