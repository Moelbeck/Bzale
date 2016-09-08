using biz2biz.ViewModel.CorporationViewModels;

namespace biz2biz.ViewModel.AccountViewModels
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int CompanyID { get; set; }
        public CompanyViewModel Company { get; set; }

    }
}
