using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Visit : Schedule
    {
        [ForeignKey("ResidentID")]
        public int ResidentID { get; set; }
        [Required, Display(Name = "Morador")]
        public virtual Resident Resident { get; set; }
        [ForeignKey("VisitorID")]
        public int VisitorID { get; set; }
        [Required, Display(Name = "Visitante")]
        public virtual Visitor Visitor { get; set; }
    }
}