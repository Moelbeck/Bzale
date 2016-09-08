using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz2biz.Repository.Interfaces
{
    public interface ICompanyRepository<T> : IDisposable
    {

        /// <summary>
        /// Gets the company by vat number
        /// </summary>
        /// <param name="vat"></param>
        /// <returns></returns>
        T GetCompany(string vat);


        /// <summary>
        /// Adds a new account. Before adding, 
        /// it have to validate if the company have less than 5 accounts - if not premium. If Premium, it doesnt matter
        /// It have to validate the mail, Password, etc.
        /// </summary>
        /// <param name="newCompany"></param>
        T AddNewCompany(T newCompany);


        /// <summary>
        /// Checks if VAT is in the database
        /// </summary>
        /// <param name="vat"></param>
        /// <returns></returns>
        bool IsVatInDatabase(string vat);

        /// <summary>
        /// Updates an account.
        /// </summary>
        /// <param name="updatedCompany"></param>
        /// <returns></returns>
        T UpdateCompany(T updatedCompany);

        bool IsEmailInDatabase(int currentcompanyid, string email);
    }
}
