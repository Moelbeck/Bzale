namespace Web2.ViewModel.CorporationViewModels
{
    public class CompanyViewModel
    {
        public int ID { get; set; }
        public string VAT { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }

        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Addresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ImageViewModel ImageViewModel { get; set; }
    }
}
