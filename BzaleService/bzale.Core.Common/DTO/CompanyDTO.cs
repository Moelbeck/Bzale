﻿
using System.ComponentModel.DataAnnotations;

namespace bzale.ViewModel
{
    public class CompanyDTO
    {
 
        public int ID { get; set; }
 
        [Display(Name = "CVR")]
        public string VAT { get; set; }
 
        [Display(Name = "Navn")]
        public string Name { get; set; }
 
        [Display(Name = "Er verificeret")]
        public bool IsVerified { get; set; }
        [Display(Name = "Land")]
        public string Country { get; set; }
 
        [Display(Name = "Postnummer")]
        public int PostalCode { get; set; }
 
        [Display(Name = "Adresse")]
        public string Address { get; set; }
 
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
 
        public ImageDTO Image { get; set; }
    }
}