﻿using System;
using System.Linq;
using bzale.Model;
using bzale.Repository.DatabaseContext;
using bzale.Repository.Abstract;
using bzale.Core.ServiceHost.Interfaces;

namespace bzale.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
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
            Company company = null;
            company = GetSingle(e => e.ID == id);
            return company;
        }

        public Company AddNewCompany(Company newCompany)
        {
            //We need to check if the person have verified it somehow
            if (!IsVatInDatabase(newCompany.VAT))
            {
                Add(newCompany);
                Save();
            }
            return GetSingle(e=>e.VAT.Equals(newCompany.VAT,StringComparison.Ordinal));
        }

        public bool IsVatInDatabase(string vat)
        {
            return GetSingle(e => e.VAT == vat)!=null;
        }

        public Company UpdateCompany(Company updatedCompany)
        {
            Edit(updatedCompany);
            Save();
            return GetSingle(e => e.ID == updatedCompany.ID);
        }

        public bool IsEmailInDatabase(string email)
        {
            return GetSingle(e => e.Email.ToLower().Trim() == email.ToLower().Trim())!=null;
        }
    }
}
