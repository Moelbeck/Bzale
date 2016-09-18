using System.ComponentModel.DataAnnotations;

namespace depross.ViewModel
{
    public class AccountCreateDTO
    {
        [Required]
        [Display(Name ="Fornavn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }
         
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
         
        [Required]
        [Display(Name = "Bekræft email")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "CVR")]
        
        public string VAT { get; set; }

        [Display(Name = "Virksomhedens navn")]
        public string CompanyName { get; set; }

        [Display(Name = "virksomhedens adresse")]
        public string CompanyAddress { get; set; }
         
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
