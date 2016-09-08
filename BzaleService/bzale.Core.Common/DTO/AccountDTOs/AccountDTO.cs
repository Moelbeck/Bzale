
using bzale.Common;

namespace bzale.ViewModel
{
    public class AccountDTO
    {
         
        public int ID { get; set; }
         
        public string FirstName { get; set; }
         
        public string LastName { get; set; }
         
        public eGender Gender { get; set; }
         
        public string Country { get; set; }
         
        public int PostalCode { get; set; }
         
        public string Address { get; set; }
         
        public string Email { get; set; }
         
        public string Phone { get; set; }

         
        public int CompanyID { get; set; }
         
        public CompanyDTO Company { get; set; }

    }
}
