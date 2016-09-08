using System.ComponentModel.DataAnnotations;

namespace biz2biz.ViewModel.Account
{
    public class AccountCreateViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Indsæt en email addresse!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Indsæt en email addresse!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }


        [Required(ErrorMessage = "CVR nummer skal indsættes")]
        [Display(Name = "CVR")]
        public string VAT { get; set; }
        [Display(Name = "Virksomhed")]
        public string CompanyName { get; set; }
        [Display(Name = "Virksomheds addresse")]
        public string CompanyAddress { get; set; }
        [Required(ErrorMessage = "Password skal indsættes korrekt")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool IsValidVAT { get; set; }
        public bool IsVatInDatabase { get; set; }
    }
}
