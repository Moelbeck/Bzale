using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2.Models;
using Web2.Repository.Context;
using Web2.Repository.Interfaces;

namespace Web2.Repository
{
    public class AccountRepository : IAccountRepository<Account>
    {
        private readonly BzaleContext context;

        public AccountRepository(BzaleContext context)
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

        public Dictionary<string, string> ValidateLogin(string email)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string email, string crypted)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account AddNewAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public Account UpdateAccount(Account updatedAccount)
        {
            throw new NotImplementedException();
        }
        public bool IsMailInDatabase(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsMailInDatabase(int currentaccount, string email)
        {
            throw new NotImplementedException();
        }

    }
}
