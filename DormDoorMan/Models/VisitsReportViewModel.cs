using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DormDoorMan.Models
{
    public class VisitsReportViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Morador")]
        public Resident Resident { get; set; }  

        [Display(Name = "Diárias")]
        public int hostingDays { get; set; }

        [Display(Name = "Diárias Extras")]
        public int extraDays { get; set; }

        [Display(Name = "Multa")]
        public int hostingFees { get; set; }
    }
}