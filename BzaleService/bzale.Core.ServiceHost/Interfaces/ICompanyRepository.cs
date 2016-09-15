using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.Core.ServiceHost.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompany(string vat);
        Company GetCompany(int id);

        Company AddNewCompany(Company newCompany);

        bool IsVatInDatabase(string vat);


        Company UpdateCompany(Company updatedCompany);

        bool IsEmailInDatabase(string email);
    }
}
