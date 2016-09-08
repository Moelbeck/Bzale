using AutoMapper;
using biz2biz.Model;
using biz2biz.Repository;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;
using biz2biz.ViewModel.CorporationViewModels;

namespace biz2biz.Service
{
    /// <summary>
    /// Contains methods for calling Company, Manufacturer and advertiser repositories.
    /// </summary>
    public class CompanyService
    {
        private ICompanyRepository<Company> _companyRepository;
        public CompanyService()
        {
            var context = new Context();
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
