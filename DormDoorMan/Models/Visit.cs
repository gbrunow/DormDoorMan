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
        [Required, Display(Name = "Morador")]
        public int ResidentID { get; set; }

        [ForeignKey("ResidentID")]
        public virtual Resident Resident { get; set; }

        [Required, Display(Name = "Visitante")]
        public int VisitorID { get; set; }
        
        [ForeignKey("VisitorID")]
        public virtual Visitor Visitor { get; set; }

        public double VisitTime
        {
            get
            {
                return ((this.CheckOut ?? DateTime.Now) - this.CheckIn).TotalHours;
            }
        }
    }
}