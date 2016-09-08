using System.Linq;
using System.Text;
using Web2.Repository;
using Web2.Enums;
using Web2.Models;
using Web2.Repository.Interfaces;
using Web2.Repository.Context;
using AutoMapper;
using System;

namespace Web2.Service
{
    /// <summary>
    /// AccountService is handling login, creation etc for accounts
    /// </summary>
    public class AccountService
    {
        private readonly IAccountRepository<Account> _accountRepository;
        private readonly ICompanyRepository<Company> _companyRepository;
        public AccountService()
        {
            var context = new BzaleContext();
            _accountRepository = new AccountRepository(context);
            _companyRepository = new CompanyRepository(context);
        }

       

    }
}
