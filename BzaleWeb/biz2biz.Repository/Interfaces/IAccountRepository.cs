using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz2biz.Repository.Interfaces
{
    public interface IAccountRepository<T> : IDisposable
    {
        /// <summary>
        /// Returns the salt and crypted password that matches the username
        /// </summary>
        /// <param name="username">is the users email or VAT number </param>
        /// <returns>a dictionary with strings: salt and crypted password. If email, it
        /// only contains one salt and one crypted. If VAT, it contains all the salts and crypted
        /// that is for the company</returns>
        Dictionary<string, string> ValidateLogin(string email);

        /// <summary>
        /// Gets the User with the email or VAT, and crypted password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="crypted"></param>
        /// <returns></returns>
        T GetAccount(string email, string crypted);

        /// <summary>
        /// Gets the account via ID
        /// This is for updating the account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetAccount(int id);
        /// <summary>
        /// Adds a new account. Before adding, 
        /// it have to validate if the company have less than 5 accounts - if not premium. If Premium, it doesnt matter
        /// It have to validate the mail, Password, etc.
        /// </summary>
        /// <param name="newAccount"></param>
        T AddNewAccount(T newAccount);

        /// <summary>
        /// Checks if Emails is in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsMailInDatabase(string email);
        /// <summary>
        /// Checks if the email is in the database, and not belonging to the current user
        /// </summary>
        /// <param name="currentaccount"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsMailInDatabase(int currentaccount, string email);
        /// <summary>
        /// Updates an account.
        /// </summary>
        /// <param name="oldid"></param>
        /// <param name="updatedAccount"></param>
        /// <returns></returns>
        T UpdateAccount(T updatedAccount);
    }
}
