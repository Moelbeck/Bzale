using System.ComponentModel.DataAnnotations;
using biz2biz.Enums;

namespace biz2biz.ViewModel.AccountViewModels
{
 public  class AccountUpdateViewModel
    {
        public int? ID { get; set; }
        [Display(Name = "For Navn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }
        [Display(Name = "Køn")]
        public eGender Gender { get; set; }

        [Display(Name = "Land")]
        public string Country { get; set; }
        [Display(Name = "Postnummer")]
        public int? PostalCode { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefon nr")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Bekræft password")]
        [Compare("Password", ErrorMessage = "Password matcher ikke!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "CVR")]
        public string VAT { get; set; }
        [Required]
        [Display(Name = "Virksomhed")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Addresse")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Telefon nr")]
        public string CompanyPhone { get; set; }
        [Display(Name = "Kontakt e-mail")]
        public string CompanyEmail { get; set; }
    }
}
