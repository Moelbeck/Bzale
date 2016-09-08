using System;
using System.Data.Entity;
using System.Linq;
using biz2biz.Model;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;

namespace biz2biz.Repository
{
    public class CompanyRepository : ICompanyRepository<Company>
    {
        private readonly Context context;

        public CompanyRepository(Context context)
        {
            this.context = context;
        }

        #region dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public Company GetCompany(string vat)
        {
            Company company = null;
            if (!string.IsNullOrWhiteSpace(vat))
            {
                company = context.Companies.FirstOrDefault(e =>e.VAT == vat);
            }
            return company;
        }

        public Company AddNewCompany(Company newCompany)
        {
            //We need to check if the person have verified it somehow
            if (!IsVatInDatabase(newCompany.VAT))
            {
                context.Companies.Add(newCompany);
                context.SaveChanges();
            }
            return newCompany;
        }

        public bool IsVatInDatabase(string vat)
        {
            return context.Companies.OfType<Company>().Any(e => e.VAT == vat);
        }

        public Company UpdateCompany(Company updatedCompany)
        {
            context.Entry(updatedCompany).State = EntityState.Modified;
            context.SaveChanges();
            return context.Companies.FirstOrDefault(e => e.ID == updatedCompany.ID);
        }

        public bool IsEmailInDatabase(int currentcompanyid, string email)
        {
            return
                context.Companies.Any(
                    e => e.Email.ToLower().Trim() == email.ToLower().Trim() && e.ID != currentcompanyid);
        }
    }
}
