using bzale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzale.WebService
{
    public interface IAccountRepository
    {
        Account GetAccount(string email);

        Account GetAccount(int id);

        Account AddNewAccount(Account newAccount);

        bool IsMailInDatabase(string email);

        Account UpdateAccount(Account updatedAccount);

        void DeleteAccount(int id);

    }
}
