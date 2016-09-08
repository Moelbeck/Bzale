using System.ComponentModel.DataAnnotations;

namespace biz2biz.ViewModel.Account
{
   public class AccountLoginViewModel
    {
       [Required(ErrorMessage = "Email/CVR er ikke korrekt")]
       [Display(Name = "Email/CVR")]
       public string UserName { get; set; }

       [Required(ErrorMessage = "Password skal indsættes korrekt")]
       [DataType(DataType.Password)]
       [Display(Name = "Password")]
       public string Password { get; set; }
    }
}
