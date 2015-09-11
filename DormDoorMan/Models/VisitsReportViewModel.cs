using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DormDoorMan.Models
{
    public class VisitsReportViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Morador")]
        public ICollection<Resident> Residents { get; set; }  

        [Display(Name = "Diárias")]
        public ICollection<int> hostingDays { get; set; }
    }
}