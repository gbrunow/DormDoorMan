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
        [Required]
        public int ResidentID { get; set; }
        
        [Display(Name = "Morador")]
        [ForeignKey("ResidentID")]
        public virtual Resident Resident { get; set; }
        
        [Required]
        public int VisitorID { get; set; }
        
        [Display(Name = "Visitante")]
        [ForeignKey("VisitorID")]
        public virtual Visitor Visitor { get; set; }

        public int VisitTime
        {
            get
            {
                DateTime chkOut = this.CheckOut ?? DateTime.Now;
                int totalDays = (int)(chkOut - CheckIn).TotalDays;

                //Currently not been usefull since the hour of check in/check out hasn't been inputed
                if (this.CheckIn.Date == chkOut.Date || (DateTime) this.CheckIn.Date == chkOut.AddDays(1))
                {
                    if ((chkOut - this.CheckIn).TotalHours >= 18 || 
                        (!this.CheckIn.IsDaylightSavingTime() && (chkOut - this.CheckIn).TotalHours >= 8))
                    {
                        totalDays++;
                    }
                }

                return totalDays;
            }
        }
    }
}