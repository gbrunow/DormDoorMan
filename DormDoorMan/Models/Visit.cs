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
        public int ResidentID { get; set; }

        [ForeignKey("ResidentID")]
        [Required, Display(Name = "Morador")]
        public virtual Resident Resident { get; set; }
        public int VisitorID { get; set; }
        
        [ForeignKey("VisitorID")]
        [Required, Display(Name = "Visitante")]
        public virtual Visitor Visitor { get; set; }
    }
}