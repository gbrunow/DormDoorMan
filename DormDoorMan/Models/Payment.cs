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
        [Required, Display(Name = "Valor Pago")]
        public double Value { get; set; }
        [Display(Name = "Comprovante")]
        public byte[] ProofOfPayment { get; set; }
        [ForeignKey("HostingID")]
        public int HostingID { get; set; }
        public virtual Hosting Hosting { get; set; }
    }
}