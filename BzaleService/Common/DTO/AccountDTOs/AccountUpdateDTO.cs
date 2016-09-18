﻿using depross.Common;
using System.ComponentModel.DataAnnotations;

namespace depross.ViewModel
{
    public class AccountUpdateDTO
    {
         
        public int ID { get; set; }
        [Required]
        [Display(Name ="Fornavne")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Fornavne")]
        public string LastName { get; set; }
         
        [Display(Name = "Køn")]
        public eGender Gender { get; set; }
         
        [Display(Name = "Land")]
        public string Country { get; set; }
        [Display(Name ="Postnummer")]
        public int? PostalCode { get; set; }
         
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
         
        [Display(Name = "Telefon")]
        public string Phone { get; set; }         
         
    }
}