using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormDoorMan.Models
{
    public enum Gender
    {
        Masculino,
        Feminino
    }

    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        /*--- Personal Information ---*/
        [Display(Name = "Nome")]
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required, StringLength(50)]        
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        [Display(Name = "Número do Passaporte")]
        public string PassportNumber { get; set; }

        [Display(Name = "Naturalidade (Cidade)")]
        public string NaturalityCity { get; set; }

        [Display(Name = "Naturalidade (Estado)")]
        public string NaturalityState { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Gênero")]
        public Gender Gender { get; set; }

        /*--- Conctact Information --*/
        [Required, Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "E-mail")]
        public string Email { get; set; }
        
        /*--- Address ---*/
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Display(Name = "Número")]
        public string Number { get; set; }

        /*-- Methods --*/
        [Display(Name = "Nome Completo")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}