using AutoMapper;
using Web2.Models;
using Web2.Repository;
using Web2.Repository.Context;
using Web2.Repository.Interfaces;
using Web2.ViewModel.CorporationViewModels;

namespace Web2.Service
{
    /// <summary>
    /// Contains methods for calling Company, Manufacturer and advertiser repositories.
    /// </summary>
    public class CompanyService
    {
        private ICompanyRepository<Company> _companyRepository;
        public CompanyService()
        {
            var context = new BzaleContext();
            _companyRepository = new CompanyRepository(context);
        }
        public bool IsVatInDatabase(string vat)
        {
            return _companyRepository.IsVatInDatabase(vat);
        }

        public CompanyViewModel GetCompanyInformation(string vat)
        {
            var company = _companyRepository.GetCompany(vat);
            CompanyViewModel viewmodel = Mapper.Map<Company, CompanyViewModel>(company);
            return viewmodel;
        }

        public bool IsCompanyEmailInDatabase(int currentcompanyid,string email)
        {
            return _companyRepository.IsEmailInDatabase(currentcompanyid,email);
        }
    }
}
