using System;
using depross.Repository.DatabaseContext;
using depross.Repository.Abstract;
using depross.Model;
using depross.Interfaces;

namespace depross.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository():this(new BzaleDatabaseContext())
        {

        }
        public CompanyRepository(BzaleDatabaseContext context) : base(context)
        {

        }
        public Company GetCompany(string vat)
        {
            Company company = null;
            if (!string.IsNullOrWhiteSpace(vat))
            {
                company = GetSingle(e =>e.VAT == vat);
            }
            return company;
        }
        public Company GetCompany(int id)
        {
            return GetSingle(e => e.ID == id); ;
        }

        public Company AddNewCompany(Company newCompany)
        {
            //We need to check if the person have verified it somehow
            if (!IsVatInDatabase(newCompany.VAT))
            {
               var added = Add(newCompany);
                Save();
                return added;
            }
            return null;
        }

        public bool IsVatInDatabase(string vat)
        {
            return GetSingle(e => e.VAT == vat)!=null;
        }

        public Company UpdateCompany(Company updatedCompany)
        {
            Edit(updatedCompany);
            Save();
            return updatedCompany;
        }

        public bool IsEmailInDatabase(string email)
        {
            return GetSingle(e => e.Email.ToLower().Trim() == email.ToLower().Trim())!=null;
        }
    }
}
