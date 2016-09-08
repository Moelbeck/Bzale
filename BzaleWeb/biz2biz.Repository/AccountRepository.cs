using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz2biz.Model;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;

namespace biz2biz.Repository
{
    public class AccountRepository : IAccountRepository<Account>
    {
        private readonly Context context;

        public AccountRepository(Context context)
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
            Dictionary<string, string> returnval = new Dictionary<string, string>();
            if (email.Contains("@"))
            {
                var temp = context.Accounts.FirstOrDefault(e => (e.Email.ToLower() == email.ToLower()));
                var salt = temp != null ? temp.PswSalt : "";
                var crypted = temp != null ? temp.CryptedPassword : "";
                returnval.Add(salt, crypted);
            }
            else //This is a search by VAT number.
            {
                var allfromcompany = context.Accounts.Where(e => e.Company.VAT == email).ToList();
                foreach (var a in allfromcompany)
                {
                    var salt = a != null ? a.PswSalt : "";
                    var crypted = a != null ? a.CryptedPassword : "";
                    returnval.Add(salt, crypted);
                }
            }
            return returnval;
        }

        public Account GetAccount(string email, string crypted)
        {
            Account account = null;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(crypted))
            {
                if (email.Contains("@")) // is a email
                    account =
                        context.Accounts.FirstOrDefault(
                            e => e.Email.ToLower() == email.ToLower() && e.CryptedPassword == crypted);
                else
                {
                    account =context.Accounts.FirstOrDefault(e => e.Company.VAT == email && e.CryptedPassword == crypted);
                }
            }
            return account;
        }

        public Account GetAccount(int id)
        {
           return context.Accounts.FirstOrDefault(e => e.ID == id && e.Deleted == null);
        }

        public Account AddNewAccount(Account newAccount)
        {
            //Company needs some kind of check if he is premium
            if (newAccount.Company != null && !IsMailInDatabase(newAccount.Email))
            {
                context.Accounts.Add(newAccount);
                context.SaveChanges();
            }
            return newAccount;
        }

        public bool IsMailInDatabase(string email)
        {
            return context.Accounts.Any(e => e.Email == email);
        }

        public Account UpdateAccount(Account updatedAccount)
        {
            context.Entry(updatedAccount).State = EntityState.Modified;
            context.SaveChanges();
            return context.Accounts.FirstOrDefault(e => e.ID == updatedAccount.ID);
        }

        public bool IsMailInDatabase(int currentaccount, string email)
        {
            return context.Accounts.Any(e => e.Email == email && e.ID != currentaccount);
        }
    }
}
