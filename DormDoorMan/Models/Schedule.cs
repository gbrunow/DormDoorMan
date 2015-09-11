using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public abstract class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Entrada"), DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Saída"), DataType(DataType.Date)]
        public DateTime? CheckOut { get; set; }
    }
}