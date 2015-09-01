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
        [RegularExpression("^[a-z A-Z]*$", ErrorMessage = "Utilize apenas letras.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required, StringLength(50)]
        [RegularExpression("^[a-z A-Z]*$", ErrorMessage = "Utilize apenas letras.")]
        public string LastName { get; set; }

        [RegularExpression("^[0-9]{11}$|^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}$", ErrorMessage = "CPF Inválido.")]
        public string CPF { get; set; }
        [RegularExpression("^[0-9]{9}$|^[0-9]{2}.[0-9]{3}.[0-9]{3}-[0-9]{1}$", ErrorMessage = "RG Inválido.")]
        public string RG { get; set; }

        [Display(Name = "Número do Passaporte")]
        //[RegularExpression("^[0-9 a-z A-Z]*$")]
        public string PassportNumber { get; set; }

        [Display(Name = "Naturalidade (Cidade)")]
        [RegularExpression("^[a-z A-Z]*$", ErrorMessage = "Utilize apenas letras.")]
        public string NaturalityCity { get; set; }

        [Display(Name = "Naturalidade (Estado)")]
        [RegularExpression("^[a-z A-Z]{2}$", ErrorMessage = "Informe a sigla do Estado e utilize apenas letras.")] //change for dropdown menu
        public string NaturalityState { get; set; }

        [Required, Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Gênero")]
        public Gender Gender { get; set; }

        /*--- Conctact Information --*/
        [Required, Display(Name = "Telefone")]
        [RegularExpression("^[+]?[0-9]*[ ]?[(]?[0-9]+[)]?[ ]?[0-9]+[-]?[0-9]+$", ErrorMessage = "Telefone Inválido.")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        /*--- Address ---*/
        [Display(Name = "CEP")]
        [RegularExpression("^[0-9]{5}[-]?[0-9]{3}", ErrorMessage = "Telefone Inválido.")]
        public string CEP { get; set; }

        [Display(Name = "Cidade")]
        [RegularExpression("^[a-z A-Z]*$", ErrorMessage = "Utilize apenas letras.")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [RegularExpression("^[a-z A-Z]{2}$", ErrorMessage = "Informe a sigla do Estado e utilize apenas letras.")] //change for dropdown menu
        public string State { get; set; }

        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Display(Name = "Número")]
        [RegularExpression("^[a-z A-Z 0-9]*$", ErrorMessage = "Número inválido.")] //change for dropdown menu
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