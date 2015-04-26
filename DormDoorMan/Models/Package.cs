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
        [ForeignKey("AddresseID")]
        public int AdresseID { get; set; }
        [Required, Display(Name = "Destinatário")]
        public virtual Resident Addresse { get; set; }

        [ForeignKey("PickUpPersonID")]
        public int PickUpPersonID { get; set; }
        [Display(Name = "Retirado por")]
        public virtual Resident PickUpPerson { get; set; }
    }
}