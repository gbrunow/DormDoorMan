using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public class Package : Schedule
    {
        public int AddresseID { get; set; }

        [ForeignKey("AddresseID")]
        [Required, Display(Name = "Destinatário")]
        public virtual Resident Addresse { get; set; }

        public int PickUpPersonID { get; set; }

        [ForeignKey("PickUpPersonID")]
        [Display(Name = "Retirado por")]
        public virtual Resident PickUpPerson { get; set; }
    }
}